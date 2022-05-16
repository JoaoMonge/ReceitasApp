
using FlightPrices;

MotorBusca m = new MotorBusca();

//Método assincrono vai continuar e responder depois

Console.WriteLine("Insira o tipo de receita que procura");
String recipe = Console.ReadLine();

await m.pesquisar(recipe);