var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoint para encriptar
app.MapPost("/encriptar", (MensajeRequest request) =>
{
    var resultado = CesarCipher.Encriptar(request.Texto, request.Desplazamiento);
    return new { textoEncriptado = resultado };
})
.WithName("Encriptar")
.WithOpenApi();

// Endpoint para desencriptar
app.MapPost("/desencriptar", (MensajeRequest request) =>
{
    var resultado = CesarCipher.Desencriptar(request.Texto, request.Desplazamiento);
    return new { textoDesencriptado = resultado };
})
.WithName("Desencriptar")
.WithOpenApi();

app.Run();

// Clase para manejar el cifrado César
class CesarCipher
{
    public static string Encriptar(string texto, int desplazamiento)
    {
        string resultado = "";
        foreach (char c in texto)
        {
            if (char.IsLetter(c))
            {
                char baseChar = char.IsUpper(c) ? 'A' : 'a';
                resultado += (char)(((c - baseChar + desplazamiento) % 26) + baseChar);
            }
            else
            {
                resultado += c;
            }
        }
        return resultado;
    }

    public static string Desencriptar(string texto, int desplazamiento)
    {
        return Encriptar(texto, 26 - (desplazamiento % 26));
    }
}

// Clase para recibir las peticiones
record MensajeRequest(string Texto, int Desplazamiento);
