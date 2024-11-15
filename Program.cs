using System.Dynamic;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using Kort_spel;

int tid = 50;

List<string> kortlek = new List<string>{
    "Ess", "Ess", "Ess", "Ess", "2", "2", "2", "2", "3", "3", "3", "3",
    "4", "4", "4", "4", "5", "5", "5", "5", "6", "6", "6", "6",
    "7", "7", "7", "7", "8", "8", "8", "8", "9", "9", "9", "9",
    "10", "10", "10", "10", "Knäkt", "Knäkt", "Knäkt", "Knäkt",
    "Dam", "Dam", "Dam", "Dam", "Kung", "Kung", "Kung", "Kung"
};


Random r = new Random();

int antalKortPerSpelare = 7;
List<string> spelare1 = new List<string>{};
List<string> spelare2 = new List<string>{};
List<string> spelare3 = new List<string>{};
List<string> spelare4 = new List<string>{};




// Dela ut kort till spelare
for (int i = 0; i < antalKortPerSpelare; i++){
    spelare1.Add(DraKort(kortlek, r));
    spelare2.Add(DraKort(kortlek, r));
    spelare3.Add(DraKort(kortlek, r));
    spelare4.Add(DraKort(kortlek, r));
    
}

// Skriv ut spelarnas händer
string mes1 = "Spelare 1: ";
string mes2 = "Spelare 2: ";
string mes3 = "Spelare 3: ";
string mes4 = "Spelare 4: ";



sakta(mes1,tid);
    vadhardeförkort(spelare1);
sakta(mes2,tid);
    vadhardeförkort(spelare2);
sakta(mes3,tid);
    vadhardeförkort(spelare3);
sakta(mes4,tid);
    vadhardeförkort(spelare4);


string check;
do{
    string mes5 = "Dina kort";
    sakta(mes5, tid);
    vadhardeförkort(spelare1);

    string mes6 = "Vilket kort vill du ta";
    sakta(mes6,tid);
    string kortetduvillha = Console.ReadLine();
    check = kortetduvillha;

    if(!spelare1.Contains(check)){
        string mes8 = "Du har inte det kortet, välj ett annat";
        sakta(mes8, tid);
    }
    
}while(!spelare1.Contains(check));


string mes7 = "Vem vill du fråga, spelare 2, 3 eller 4. Skriv 2, 3 eller 4";
sakta(mes7, tid);


int frågavilkenspelare = int.Parse(Console.ReadLine());

if(frågavilkenspelare == 2){
    DraKort_frånhand(ref spelare1, ref spelare2, check, frågavilkenspelare);
}

if(frågavilkenspelare == 3){

}

if(frågavilkenspelare == 4){

}




// Funktion för att dra ett kort från kortleken och ta bort det från leken
static string DraKort(List<string> kortlek, Random r){
    int index = r.Next(kortlek.Count);         // Dra ett slumpmässigt index
    string kort = kortlek[index];           // Få kortet på det indexet
    kortlek.RemoveAt(index);                // Ta bort kortet från kortleken
    return kort;                            // Returnera kortet
}

static void DraKort_frånhand(ref List<string> spelare, ref List<string> andrahand, string vilketkort, int a){
    int hurmånga = 0;
    string mes1 = "spelare" + a + " Hade " + hurmånga + " " + vilketkort;

    if(andrahand.Contains(vilketkort)){
        do{
            andrahand.Remove(vilketkort);
            spelare.Add(vilketkort);
            hurmånga++;
        }while(andrahand.Contains(vilketkort));

        sakta(mes1, 50);
    }
    else{
        sakta(mes1, 50);
    }

    
}

static void sakta(string mes, int tid){
    foreach (char c in mes){
        Console.Write(c);
        Thread.Sleep(tid);
    }
    Console.WriteLine();
}

static void vadhardeförkort(List<string> spelare){
    foreach(string dinhand in spelare){
        Console.Write(dinhand + " ");
    }
    Console.WriteLine();
    Console.WriteLine();
}



// Detta är den gamla koden innan jag frågade chatgpt för jag kunde inte få det att göra som jag ville.
/*
String[] kort = ["null", "Ess","Ess","Ess","Ess", "2","2","2","2", "3","3","3","3", "4",//1-13
                "4","4","4", "5","5","5","5", "6","6","6","6", "7","7",//14-26
                "7","7", "8","8","8","8", "9", "9", "9", "9", "10","10","10",//27-39
                "10", "Knäkt","Knäkt","Knäkt","Knäkt", "Dam","Dam","Dam","Dam", "Kung","Kung","Kung","Kung",];//40-52          

string spelare1 = "";
string spelare2;
string spelare3;
string spelare4;


for(int i = 1; i < 8; i++){
    Random r = new Random();
    int rnd = r.Next(1, 54);
    spelare1 = spelare1 + kort[rnd] + " ";
}

Console.WriteLine(spelare1);

static void sakta(string mes, int tid){
    foreach (char c in mes){
        Console.Write(c);
        Thread.Sleep(tid);
    }
    Console.WriteLine();
}
*/
