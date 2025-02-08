using UnityEngine;

public class MovimientoFondo : MonoBehaviour
{
    public RectTransform fondo1;
    public RectTransform fondo2;
    public float velocidad = 100f;

    private float alturaImagen;

    void Start()
    {
        alturaImagen = fondo1.rect.height - 1;
    }

    void Update()
    {
        MoverFondo(fondo1);
        MoverFondo(fondo2);

        if (fondo1.anchoredPosition.y <= -alturaImagen)
        {
            fondo1.anchoredPosition = new Vector2(fondo1.anchoredPosition.x, Mathf.RoundToInt(fondo2.anchoredPosition.y + alturaImagen));
        }
        if (fondo2.anchoredPosition.y <= -alturaImagen)
        {
            fondo2.anchoredPosition = new Vector2(fondo2.anchoredPosition.x, Mathf.RoundToInt(fondo1.anchoredPosition.y + alturaImagen));
        }
    }

    void MoverFondo(RectTransform fondo)
    {
        fondo.anchoredPosition -= new Vector2(0, velocidad * Time.deltaTime);
    }
}
