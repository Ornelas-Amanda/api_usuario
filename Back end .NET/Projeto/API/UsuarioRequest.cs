//Classe que popula em massa os campos da tabela

public record UsuarioRequest(
    string Id, string Nome, string Sobrenome, string Email, string Dt, string Escolaridade
    );
