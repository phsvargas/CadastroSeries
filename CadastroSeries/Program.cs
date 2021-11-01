using System.Threading.Tasks;
using CadastroSeries.Classes;
using CadastroSeries.Enum;

class Program
{
    static SerieRepositorio repositorio = new SerieRepositorio();
    static void Main(string[] args)
    {
        Console.WriteLine();
        Console.WriteLine("Blockbuster series e filmes da sua vida!");
        Console.WriteLine("Informe a opção desejada:");

        string opcaoUsuario = ObterOpcaoUsuario();

        while (opcaoUsuario.ToUpper() != "X")
        {
            switch (opcaoUsuario)
            {
                case "1":
                    Console.WriteLine();
                    Console.WriteLine("Opção selecionada: Lista Series");
                    ListarSeries();
                    break;

                case "2":
                    Console.WriteLine("Opção selecionada: Inserir serie");
                    InserirSerie();
                    break;

                case "3":
                    Console.WriteLine("Opção selecionada: Atualizar serie");
                    AtualizarSerie();
                    break;

                case "4":
                    Console.WriteLine("Opção selecionada: Excluir Serie");
                    ExcluirSeire();
                    break;

                case "5":
                    Console.WriteLine("Opção selecionada: Visualizar serie");
                    VisualizaSerie();
                    break;
                case "C":
                    Console.WriteLine("Opção selecionada: Limpar tela");
                    Console.Clear();
                    break;
                default:
                    throw new ArgumentException();
            }

            opcaoUsuario = ObterOpcaoUsuario();
        }

        Console.WriteLine("Obrigado pela preferenceia e volte sempre!!");
        Console.WriteLine();
    }
    private static string ObterOpcaoUsuario()
    {
        Console.WriteLine("1 - Listar series");
        Console.WriteLine("2 - Inserir nova serie");
        Console.WriteLine("3 - Atualizar serie");
        Console.WriteLine("4 - Excluir serie");
        Console.WriteLine("5 - Visualizar serie");
        Console.WriteLine("C - Limpar tela");
        Console.WriteLine("X - Sair");
        Console.WriteLine();

        string opcaoUsuario = Console.ReadLine().ToUpper().Trim();
        Console.WriteLine();
        return opcaoUsuario;
    }

    private static void ListarSeries()
    {
        
        Console.WriteLine();

        var lista = repositorio.Lista();

        if(lista.Count == 0)
        {
            Console.WriteLine("Nenhuma serie econtrada.");
            Console.WriteLine();
            return;
        }
        
        foreach(var serie in lista)
        {
            Console.WriteLine("Serie: ({0}) {1}", serie.RetornaId(), serie.RetornaTitulo());
        }
        Console.WriteLine();
    }

    private static void InserirSerie()
    {
        Console.WriteLine();


        ListaGenero();
        Console.WriteLine("Digite o genero de acordo com as opção que estão acima.");
        int entradaGenero = int.Parse(Console.ReadLine().Trim());

        Console.WriteLine();
        Console.WriteLine("Digite o nome da serie:");
        string nomeSerie = Console.ReadLine().Trim();

        Console.WriteLine();
        Console.WriteLine("Digite uma breve descrição do titulo:");
        string descricaoSerie = Console.ReadLine().Trim();

        Console.WriteLine();
        Console.WriteLine("Digite o ano em que a serie foi lançada:");
        
        int anoSerie = int.Parse(Console.ReadLine().Trim());

        Serie novaSerie = new Serie
        (
            id: repositorio.ProximoId(),
            genero: (Genero)entradaGenero,
            titulo: nomeSerie,
            descricao: descricaoSerie,
            ano: anoSerie
        ) ;

        repositorio.Insere(novaSerie);
        Console.WriteLine();
    }

    private static void AtualizarSerie()
    {


        ListarSeries();
        Console.WriteLine();
        Console.WriteLine("Digite o id da serie que deseja alterar:");
        int idSerie = int.Parse(Console.ReadLine());
        Console.WriteLine();
        var serieEscolhida = repositorio.Lista()[idSerie];

        Console.WriteLine("Titulo: "+serieEscolhida.Titulo);
        Console.WriteLine("Ano: " + serieEscolhida.Ano);
        Console.WriteLine("Descrição: " + serieEscolhida.Descricao);
        Console.WriteLine("Genêro: " + serieEscolhida.Genero);
        Console.WriteLine();
        Console.WriteLine("Das informações mostradas acima você deseja atualizar todas as informações? (S/N)");
        string escolha = Console.ReadLine().ToUpper().Trim();

        if (escolha.ToUpper() == "N")
        {
            Console.WriteLine("(1) - Titulo");
            Console.WriteLine("(2) - Ano");
            Console.WriteLine("(3) - Descrição");
            Console.WriteLine("(4) - Genêro");
            Console.WriteLine("Digite o Id da informação que deseja mudar (caso seja mais de uma separe por virgulas os ids):");
            string idMudanca = Console.ReadLine();

            foreach ( string mudanca in idMudanca.Split(','))
            {
                switch (mudanca)
                {
                    case "1":
                        Console.WriteLine("Digite o novo titulo:");
                        serieEscolhida.Titulo = Console.ReadLine().Trim();
                        break;
                    case "2":
                        Console.WriteLine("Digite o ano em que a serie foi lançada:");
                        serieEscolhida.Ano = int.Parse(Console.ReadLine().Trim());
                        break;
                    case "3":
                        Console.WriteLine("Digite a nova descrição da serie:");
                        serieEscolhida.Descricao = Console.ReadLine().Trim();
                        break;
                    case "4":
                        ListaGenero();
                        Console.WriteLine("Digite o id do genero conforme mostrado acima:");
                        serieEscolhida.Genero = (Genero)int.Parse(Console.ReadLine().Trim());
                        break;
                }
            }
            
        }
        else
        {
            Console.WriteLine("Digite o novo titulo:");
            serieEscolhida.Titulo = Console.ReadLine().Trim();
            Console.WriteLine();
            Console.WriteLine("Digite o ano em que a serie foi lançada:");
            serieEscolhida.Ano = int.Parse(Console.ReadLine().Trim());
            Console.WriteLine();
            Console.WriteLine("Digite a descrição da sereie:");
            serieEscolhida.Descricao = Console.ReadLine().Trim();
            Console.WriteLine();
            ListaGenero();
            Console.WriteLine();
            Console.WriteLine("Digite o id do genero escolhido");
            serieEscolhida.Genero = (Genero)int.Parse(Console.ReadLine());


        }

        Serie novaSerie = new Serie
        (
            id: idSerie,
            genero: serieEscolhida.Genero,
            titulo: serieEscolhida.Titulo,
            descricao: serieEscolhida.Descricao,
            ano: serieEscolhida.Ano
        );
        Console.WriteLine("Serie atualizada com sucesso!");



    }

    private static void ListaGenero()
    {
        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
        }
    }

    private static void ExcluirSeire()
    {
        var lista = repositorio.Lista();
        ListarSeries();
        Console.WriteLine("Digite o id da sere que você deseja remover");
        int escolha = int.Parse(Console.ReadLine());
        repositorio.Exclui(escolha);
        Console.WriteLine();
        Console.WriteLine("Serie excluida com sucesso!");
    }

    public static void VisualizaSerie()
    {
        Console.WriteLine();
        ListarSeries();
        Console.WriteLine();
        Console.WriteLine("Digite o id da serie que deseja visualizar:");
        int escolha = int.Parse(Console.ReadLine());
        var serieEscolhida = repositorio.Lista()[escolha];

        Console.WriteLine();
        Console.WriteLine("Titulo: " + serieEscolhida.Titulo);
        Console.WriteLine("Ano: " + serieEscolhida.Ano);
        Console.WriteLine("Descrição: " + serieEscolhida.Descricao);
        Console.WriteLine("Genêro: " + serieEscolhida.Genero);
        Console.WriteLine();
    }
}

