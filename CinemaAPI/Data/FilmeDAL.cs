using CinemaAPI.Models;


namespace CinemaAPI.Data;

public class FilmeDAL
{
    private readonly CinemaContext context;

    public FilmeDAL(CinemaContext context)
    {
        this.context = context; 
    }

    
    public ICollection<Filme> ListarFilmes(int skip, int take) => [ ..this.context.Filmes.Skip(skip).Take(take) ];

    public void AdicionarFilme(Filme filme)
    {
        context.Filmes.Add(filme);
        context.SaveChanges();
    }

    public void AtualizarFilme(Filme filme)
    {
        context.Filmes.Update(filme);
        context.SaveChanges();
    }

    public void DeletarFilme(Filme filme)
    {
        context.Filmes.Remove(filme);
        context.SaveChanges();
    }

    public Filme? BuscarFilmePorId(int id) => this.context.Filmes.FirstOrDefault(filme => filme.Id.Equals(id));

    public ICollection<Filme> BuscarFilmesPorTitulo(string titulo) => [ ..this.context.Filmes.Where(filme => filme.Titulo.ToLower().Contains(titulo.ToLower())) ];
}
