# LibreriaVisualFinal

**Autor:** Salvador Bueno González

## Guía de Instalación Rápida

Para utilizar esta librería en tu proyecto WPF, sigue estos pasos:

1.  **Agregar Referencia:**
    *   Haz clic derecho en "Referencias" en tu proyecto.
    *   Selecciona "Agregar referencia..." y busca el archivo `LibreriaVisualFinal.dll` (compilado o proyecto).

2.  **Declarar Namespace en XAML:**
    En la cabecera de tu archivo XAML (Window, UserControl, etc.), añade la siguiente línea para importar los controles:
    ```xml
    xmlns:final="http://miscontroles.com/final"
    ```

3.  **Usar los Controles:**
    Ahora puedes instanciar los controles utilizando el prefijo definido:
    ```xml
    <final:VisorProgreso MensajeAccion="Cargando..." ProgresoValor="50" />
    <final:BotonVisual Content="Haz Clic" Width="100" Height="30" />
    ```

## Tabla de Referencia

A continuación se detallan los controles disponibles y sus propiedades principales (Dependency Properties).

| Control | Propiedad (DP) | Descripción |
| :--- | :--- | :--- |
| **VisorProgreso** | `MensajeAccion` | Cadena de texto que muestra la acción actual al usuario (ej. "Guardando datos..."). Por defecto: "Esperando interacción...". |
| **VisorProgreso** | `ProgresoValor` | Valor numérico (double) que representa el porcentaje de progreso (0 a 100). |
| **BotonVisual** | *(Heredado)* | Botón personalizado que cambia su color de fondo a un valor RGB aleatorio cada vez que se presiona. Extiende de `Button`. |

## Nota Técnica Crítica

> **IMPORTANTE: Configuración de Arquitectura**
>
> Para garantizar la compatibilidad completa, especialmente si se integra en soluciones que utilizan bases de datos como **SQLite**, es **OBLIGATORIO** configurar la arquitectura de la solución a **x86**.
>
> *   **Plataforma:** x86
> *   **Framework:** .NET Framework 4.7.2
>
> Si no se configura correctamente, podrían producirse excepciones en tiempo de ejecución relacionadas con la carga de librerías nativas.
