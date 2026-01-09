using CinemaAPI.Models;

namespace CinemaAPI.Data;

public class DAL<T> where T : class
{
    private readonly CinemaContext context;

    public DAL(CinemaContext context)
    {
        this.context = context;
    }

    public ICollection<T> Listar(int skip, int take) => [.. this.context.Set<T>().Skip(skip).Take(take)];

    public void Adicionar(T obj)
    {
        context.Set<T>().Add(obj);
        context.SaveChanges();
    }

    public void Atualizar(T obj)
    {
        context.Set<T>().Update(obj);
        context.SaveChanges();
    }

    public void Deletar(T obj)
    {
        context.Set<T>().Remove(obj);
        context.SaveChanges();
    }

    public T? BuscarPor(Func<T, bool> condicao) => context.Set<T>().FirstOrDefault(condicao);

    public ICollection<T> FiltrarPor(Func<T, bool> condicao) => [.. context.Set<T>().Where(condicao)];
}
