//Repositorio criado para salvar iniciar, pegar, adionar e remover os dados em uma lista
public static class RepositorioUsuario{

    public static List<Usuario> Usuarios { get; set; } = Usuarios = new List<Usuario>();


//Inicia a lista com dados pre prontos, para nao iniciar como nulo
    public static void Init(IConfiguration configuration){
       var usuarios = configuration.GetSection("Usuarios").Get<List<Usuario>>(); 
       Usuarios = usuarios;
    }


//Adiciona os dados
    public static void Add(Usuario usuario){
       Usuarios.Add(usuario) ;  
    }
//Busca os dados
    public static Usuario GetBy(string id){
        return Usuarios.FirstOrDefault(p => p.Id == id);
    }


//remove os dados
    public static void Remove(Usuario usuario){
        Usuarios.Remove(usuario);
    }
}
