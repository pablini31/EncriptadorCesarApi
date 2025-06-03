# API de Cifrado César

API REST que implementa el cifrado César, permitiendo encriptar y desencriptar mensajes.

## Características

- Endpoint para encriptar mensajes
- Endpoint para desencriptar mensajes
- Soporte para letras mayúsculas y minúsculas
- Preserva caracteres especiales y espacios
- Documentación con Swagger

## Endpoints

### Encriptar
- **URL**: `/encriptar`
- **Método**: POST
- **Body**:
```json
{
    "texto": "Mensaje a encriptar",
    "desplazamiento": 3
}
```

### Desencriptar
- **URL**: `/desencriptar`
- **Método**: POST
- **Body**:
```json
{
    "texto": "Mensaje encriptado",
    "desplazamiento": 3
}
```

## Tecnologías
- .NET 7
- ASP.NET Core
- Swagger/OpenAPI

## Requisitos

- .NET 9.0 SDK o superior

## Cómo ejecutar

1. Clona el repositorio
2. Navega al directorio del proyecto
3. Ejecuta el siguiente comando:
   ```bash
   dotnet run
   ```
4. Abre tu navegador y ve a `http://localhost:5258/swagger`

## Uso

### Encriptar un mensaje
```http
POST /encriptar
Content-Type: application/json

{
    "texto": "Tu mensaje",
    "desplazamiento": 3
}
```

### Desencriptar un mensaje
```http
POST /desencriptar
Content-Type: application/json

{
    "texto": "Mensaje encriptado",
    "desplazamiento": 3
}
```

## Ejemplo

Para encriptar "Hola" con un desplazamiento de 3:
```json
{
    "texto": "Hola",
    "desplazamiento": 3
}
```

Respuesta:
```json
{
    "textoEncriptado": "Krod"
}
``` 