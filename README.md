# LibreriaVisualFinal (WPF) — Manual de Referencia Profesional

## Ficha del Proyecto y Autor

- **Nombre de la librería**: `LibreriaVisualFinal`
- **Tipo**: Librería de controles WPF (Custom Control + UserControl)
- **Framework objetivo**: **.NET Framework 4.7.2**
- **Autor**: **Salvador Bueno González**

---

## Guía de Instalación Rápida

1. **Compila la librería**
   - En Visual Studio, compila el proyecto `LibreriaVisualFinal` en **Debug** o **Release**.
   - La DLL se generará en `LibreriaVisualFinal/bin/<Debug|Release>/LibreriaVisualFinal.dll`.

2. **Referencia la DLL desde tu proyecto WPF**
   - En tu proyecto consumidor: **Referencias > Agregar referencia... > Examinar**
   - Selecciona `LibreriaVisualFinal.dll`.

   > Alternativa recomendada: añade una **Referencia de Proyecto** si la solución contiene ambos proyectos.

3. **Importa el XMLNS de la librería en XAML**
   - La librería expone un XMLNS estable (mapeado por assembly) para usarlo en XAML:

```xml
xmlns:final="http://miscontroles.com/final"
```

4. **Usa los controles**

```xml
<final:BotonVisual Content="Pulsa para cambiar de color" />

<final:VisorProgreso
    MensajeAccion="Cargando datos..."
    ProgresoValor="35" />
```

5. **(Opcional) Estilo por defecto de `BotonVisual`**
   - `BotonVisual` tiene estilo/plantilla por defecto en `Themes/Generic.xaml`. Si en tu XAML lo estás anulando con `Style="{x:Null}"`, **elimínalo** para que se aplique el estilo de la librería.

---

## Tabla de Referencia (Controles y Dependency Properties)

| Control | Propiedad (DP) | Descripción |
|---|---|---|
| `BotonVisual` | — | Botón personalizado que cambia su `Background` a un color aleatorio al hacer clic. No define DP propias (usa las estándar de `Button`). |
| `VisorProgreso` | `MensajeAccionProperty` | Texto descriptivo del estado/acción actual (por defecto: `"Esperando interacción..."`). |
| `VisorProgreso` | `ProgresoValorProperty` | Valor numérico de progreso (típicamente \(0–100\)) mostrado en la barra. |

---

## Nota Técnica Crítica (x86 / SQLite / Compatibilidad)

Aunque esta librería **no incluye SQLite directamente**, es habitual que el proyecto que la consuma utilice **SQLite** (por ejemplo, con paquetes como `System.Data.SQLite`) y ahí aparece el problema típico de compatibilidad de arquitectura:

- **Si tu proyecto usa SQLite con binarios nativos x86**, debes configurar la plataforma a **x86** para evitar errores como `BadImageFormatException` o fallos de carga de ensamblados nativos.
- **Recomendación práctica**:
  - En Visual Studio: **Propiedades del proyecto > Build > Platform target: x86**.
  - Si trabajas con **AnyCPU**, activa **Prefer 32-bit** cuando corresponda (según el paquete SQLite usado).
- **Alineación de versiones**: mantén consistente el **Target Framework (.NET 4.7.2)** entre la app WPF y la librería para evitar conflictos de referencia.

