using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Dominio.ModuloContato;
using eAgenda.Dominio.ModuloDespesa;
using eAgenda.Dominio.ModuloTarefa;
using eAgenda.Infra.Dados.Arquivo.ModuloCompromisso;
using eAgenda.Infraestrutura.Arquivos.Compartilhado;
using eAgenda.Infraestrutura.Arquivos.ModuloCategoria;
using eAgenda.Infraestrutura.Arquivos.ModuloContato;
using eAgenda.Infraestrutura.Arquivos.ModuloDespesa;
using eAgenda.Infraestrutura.Arquivos.ModuloTarefa;
using eAgenda.WebApp.ActionFilters;

namespace eAgenda.WebApp
{
#pragma warning disable RCS1102 // Make class static
    public class Program
#pragma warning restore RCS1102 // Make class static
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews((options) => options.Filters.Add<ValidarModeloAttribute>());
            builder.Services.AddScoped((IServiceProvider _) => new ContextoDados(true));
            builder.Services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmArquivo>();
            builder.Services.AddScoped<IRepositorioCompromisso, RepositorioCompromissoEmArquivo>();
            builder.Services.AddScoped<IRepositorioContato, RepositorioContatoEmArquivo>();
            builder.Services.AddScoped<IRepositorioDespesa, RepositorioDespesaEmArquivo>();
            builder.Services.AddScoped<IRepositorioTarefa, RepositorioTarefaEmArquivos>();

            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapDefaultControllerRoute();
            app.Run();
        }
    }
}
