# LibreriaVisualFinal

## Librería de Controles WPF Personalizados

**Autor:** Salvador Bueno González  
**Versión:** 1.0.0  
**Framework:** .NET Framework 4.7.2  
**Plataforma:** Windows Presentation Foundation (WPF)

---

## Descripción

LibreriaVisualFinal es una biblioteca de controles visuales personalizados para aplicaciones WPF. Incluye componentes reutilizables diseñados para mejorar la experiencia de usuario en aplicaciones de escritorio Windows, con un estilo visual moderno y oscuro.

---

## Guía de Instalación Rápida

Sigue estos pasos para integrar la librería en tu proyecto WPF:

### Paso 1: Añadir la referencia a la DLL

1. En el **Explorador de Soluciones**, haz clic derecho sobre **Referencias** de tu proyecto.
2. Selecciona **Agregar referencia...**.
3. En la pestaña **Examinar**, navega hasta la ubicación del archivo `LibreriaVisualFinal.dll`.
   - Ruta típica: `LibreriaVisualFinal/bin/Debug/LibreriaVisualFinal.dll`
4. Selecciona el archivo y haz clic en **Aceptar**.

### Paso 2: Declarar el namespace en XAML

Añade el namespace XML de la librería en la etiqueta raíz de tu ventana o control XAML:

```xml
xmlns:final="http://miscontroles.com/final"
```

**Ejemplo completo de declaración en Window:**

```xml
<Window x:Class="MiProyecto.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:final="http://miscontroles.com/final"
        Title="Mi Aplicación" Height="450" Width="800">
```

### Paso 3: Utilizar los controles

Una vez declarado el namespace, puedes usar los controles con el prefijo `final:`:

```xml
<!-- Botón con cambio de color aleatorio al hacer clic -->
<final:BotonVisual Content="Pulsar para cambiar color" Width="200" Height="40" />

<!-- Visor de progreso con mensaje y barra -->
<final:VisorProgreso MensajeAccion="Cargando datos..." ProgresoValor="75" />
```

---

## Tabla de Referencia de Controles

### Controles Disponibles

| Control | Propiedad (DP) | Tipo | Descripción |
|---------|----------------|------|-------------|
| **BotonVisual** | *(Heredadas de Button)* | - | Botón personalizado que cambia su color de fondo a un valor RGB aleatorio cada vez que se pulsa. Ideal para retroalimentación visual o efectos demostrativos. |
| **VisorProgreso** | `MensajeAccion` | `string` | Texto descriptivo que se muestra en el visor. Indica al usuario el estado actual de la operación. **Valor por defecto:** `"Esperando interacción..."` |
| **VisorProgreso** | `ProgresoValor` | `double` | Porcentaje de progreso mostrado en la barra de progreso. Valores esperados entre 0 y 100. **Valor por defecto:** `0` |

### Detalle de Dependency Properties

#### VisorProgreso

| Propiedad | Tipo | Valor por Defecto | Bindable | Descripción Técnica |
|-----------|------|-------------------|----------|---------------------|
| `MensajeAccion` | `string` | `"Esperando interacción..."` | Sí | Cadena de texto enlazable que se presenta en la parte superior del control. Se recomienda enlazar desde el ViewModel para actualizaciones dinámicas. |
| `ProgresoValor` | `double` | `0` | Sí | Valor numérico que representa el porcentaje de progreso. El control **no valida** automáticamente el rango; asegúrate de que los valores estén entre 0 y 100 antes de asignarlos. |

#### BotonVisual

| Propiedad | Tipo | Descripción |
|-----------|------|-------------|
| `Content` | `object` | Contenido del botón (texto, imagen, etc.). Heredada de `Button`. |
| `Background` | `Brush` | Color de fondo del botón. Se actualiza automáticamente a un color aleatorio al hacer clic. **Valor inicial:** `#3A3A3A` |
| `Foreground` | `Brush` | Color del texto. **Valor por defecto:** `White` |
| `FontSize` | `double` | Tamaño de fuente. **Valor por defecto:** `15` |
| `FontWeight` | `FontWeight` | Peso de la fuente. **Valor por defecto:** `SemiBold` |
| `Padding` | `Thickness` | Espaciado interno. **Valor por defecto:** `14,10` |

---

## Ejemplos de Uso

### Ejemplo 1: BotonVisual básico

```xml
<final:BotonVisual 
    x:Name="btnAccion" 
    Content="Lanzar Acción Visual" 
    Width="200" 
    Height="45" />
```

### Ejemplo 2: VisorProgreso con binding

```xml
<final:VisorProgreso 
    MensajeAccion="{Binding EstadoActual}" 
    ProgresoValor="{Binding PorcentajeCompletado}" />
```

### Ejemplo 3: VisorProgreso con valores estáticos

```xml
<final:VisorProgreso 
    MensajeAccion="Procesando archivos..." 
    ProgresoValor="50" 
    Margin="10" />
```

---

## Nota Técnica Crítica

> ⚠️ **IMPORTANTE: Configuración de Arquitectura x86**

### Compatibilidad con SQLite

Si tu proyecto utiliza **SQLite** como base de datos (por ejemplo, `System.Data.SQLite`), es **obligatorio** configurar la arquitectura de compilación en **x86** para garantizar la compatibilidad:

#### Pasos para configurar x86 en Visual Studio:

1. Ve al menú **Compilar** → **Administrador de configuración...**
2. En la columna **Plataforma** de tu proyecto, selecciona **x86**.
   - Si no existe, haz clic en **<Nueva...>** y selecciona **x86** como nueva plataforma.
3. Asegúrate de que **tanto la solución como el proyecto** estén configurados en **x86**.
4. Guarda y recompila la solución.

#### ¿Por qué x86?

SQLite utiliza bibliotecas nativas que deben coincidir con la arquitectura del proceso. La configuración **AnyCPU** puede causar excepciones del tipo:

- `BadImageFormatException`
- `DllNotFoundException`
- `Unable to load DLL 'SQLite.Interop.dll'`

### Otras Consideraciones Técnicas

| Aspecto | Requisito |
|---------|-----------|
| **Framework mínimo** | .NET Framework 4.7.2 |
| **Sistema Operativo** | Windows 7 SP1 o superior |
| **Visual Studio** | 2017 o superior (recomendado 2019/2022) |
| **Dependencias** | PresentationFramework, PresentationCore, WindowsBase, System.Xaml |

### Resolución de Problemas Comunes

| Problema | Solución |
|----------|----------|
| El control no aparece en el diseñador | Recompila la solución y reinicia Visual Studio. |
| Error de namespace no encontrado | Verifica que la referencia a la DLL esté correctamente añadida. |
| Estilos no se aplican | Asegúrate de no sobrescribir el `Style` con `Style="{x:Null}"` a menos que sea intencional. |
| Excepción al usar SQLite | Configura la plataforma de compilación en x86. |

---

## Estructura del Proyecto

```
LibreriaVisualFinal/
├── BotonVisual.cs           # Control de botón con color aleatorio
├── VisorProgreso.xaml       # Diseño XAML del visor de progreso
├── VisorProgreso.xaml.cs    # Lógica del visor de progreso
├── Themes/
│   └── Generic.xaml         # Estilos por defecto de los controles
├── Properties/
│   └── AssemblyInfo.cs      # Información del ensamblado
└── bin/Debug/
    └── LibreriaVisualFinal.dll  # Librería compilada
```

---

## Licencia

Este proyecto ha sido desarrollado con fines educativos.

---

*Documentación generada para LibreriaVisualFinal v1.0.0*
