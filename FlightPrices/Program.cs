using FlightPrices;

//Classe principal inclui os métodos que acedem a internet para obter as receitas
MotorBusca m = new MotorBusca();

//Pedir ao utilizador para inserir qual o tipo receita que quer
Console.WriteLine("Insira o tipo de receita que procura");
String recipe = Console.ReadLine();

// O Await serve para aguardar que o método termine de consultar a
// internet sem passar para a linha de código
m.pesquisar(recipe);

//Enquanto o programa aguarda receber as informações da internet mostra ao utilizador uma barra de loading 
Console.WriteLine("LOADING:");
while (m.recipes.Count <= 0)
{
    Console.Write("#");
    //Pausa 100 milesegundos
    Thread.Sleep(100);
}
//Para quebrar a linha da barra loading
Console.WriteLine();

voltar:
m.listarReceitas();
Console.WriteLine("Escolha a receita:");

int id = Int32.Parse(Console.ReadLine());

Recipe r = m.getById(id);

if (r == null)
{
    Console.WriteLine("id inválido");
    goto voltar;
}

voltaraqui:
Console.WriteLine("Para ver:\n1)Nome e descricao\n2)Instrucoes\n3)Tempo estimado\n4)Sair");
int opcao = Int16.Parse(Console.ReadLine());

switch (opcao) {
        case 1:
            r.mostrarNomeDescricao();
            goto voltaraqui;
        case 2:
            r.mostrarInstrucoes();
            goto voltaraqui;
        case 3:
            r.mostrarTempoEstimado();
            goto voltaraqui;
        case 4:
            System.Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Opção inválida. Tente de novo");
            goto voltaraqui;
            
}


