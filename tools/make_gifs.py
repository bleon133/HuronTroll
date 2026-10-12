"""
Genera GIFs animados a partir de las hojas de sprites de HuronTroll.
Uso: python tools/make_gifs.py
Salida: docs/img/gifs/*.gif
"""
import os
from PIL import Image

ROOT = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
ASSETS = os.path.join(ROOT, "Assets")
OUT = os.path.join(ROOT, "docs", "img", "gifs")

SCALE = 3
DURATION = 110
TRANSPARENT = (0, 0, 0, 0)


def frames_from_sheet(path, frame_w=64, frame_h=64):
    """Recorta una hoja horizontal en frames. Si la hoja no es multiplo exacto,
    reparte el ancho entre frames del tamano pedido."""
    img = Image.open(path).convert("RGBA")
    w, h = img.size
    n = max(1, w // frame_w)
    fh = frame_h if h >= frame_h else h
    out = []
    for i in range(n):
        box = (i * frame_w, 0, min((i + 1) * frame_w, w), fh)
        out.append(img.crop(box))
    return out


def strip_empty(frames):
    keep = [f for f in frames if f.getbbox() is not None]
    return keep or frames


def save_gif(frames, name, scale=SCALE, duration=DURATION):
    os.makedirs(OUT, exist_ok=True)
    flat = []
    for f in frames:
        big = f.resize((f.width * scale, f.height * scale), Image.NEAREST)
        bg = Image.new("RGBA", big.size, (24, 22, 30, 255))
        bg.alpha_composite(big)
        flat.append(bg.convert("P", palette=Image.ADAPTIVE, colors=255))
    out = os.path.join(OUT, name)
    flat[0].save(out, save_all=True, append_images=flat[1:],
                 duration=duration, loop=0, disposal=2)
    print(f"  {name}  ({len(flat)} frames, {flat[0].width}x{flat[0].height})")


def ss(*parts):
    return os.path.join(ASSETS, *parts)


def main():
    print("Generando GIFs de HuronTroll...")
    pa = ("pixelArt",)
    el = ("pixelArt", "Elementos")

    # --- Huron: animaciones ---
    anims = [
        ("Idle.png", "huron-idle.gif"),
        ("personaje izquierda.png", "huron-correr.gif"),
        ("salto.png", "huron-salto.gif"),
        ("agachado movimientoFinal.png", "huron-agachado.gif"),
        ("muerte.png", "huron-muerte.gif"),
        ("xddddd.png", "huron-caida.gif"),
    ]
    for f, name in anims:
        p = ss(*pa, f)
        if os.path.exists(p):
            save_gif(strip_empty(frames_from_sheet(p)), name)
        else:
            print(f"  (falta) {f}")

    # --- Elementos ---
    elems = [
        (os.path.join(*el, "chispa.png"), "elemento-chispa.gif"),
        (os.path.join(*pa, "fuego.png"), "elemento-fuego.gif"),
        (os.path.join(*el, "manzana.png"), "elemento-manzana.gif"),
    ]
    for p, name in elems:
        full = ss(*p.split(os.sep))
        if os.path.exists(full):
            save_gif(strip_empty(frames_from_sheet(full, 50, 50)), name)
        else:
            print(f"  (falta) {p}")

    print("Listo.")


if __name__ == "__main__":
    main()
