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

int frågavilkenspelare = 0;
string check = "";
duvillta(ref spelare1, ref check, ref frågavilkenspelare, ref spelare2, ref spelare3, ref spelare4);







// Funktion för att dra ett kort från kortleken och ta bort det från leken


static void duvillta(ref List<string> spelare, ref string check, ref int frågavilkenspelare, ref List<string> spelare2, ref List<string> spelare3, ref List<string> spelare4){
    int tid = 50;
    int breek = 0;
    do{
        string mes5 = "Dina kort";
        sakta(mes5, tid);
        vadhardeförkort(spelare);

        string mes6 = "Vilket kort vill du ta";
        sakta(mes6,tid);
        string kortetduvillha = Console.ReadLine();
        check = kortetduvillha;

        if(!spelare.Contains(check)){
            string mes8 = "Du har inte det kortet, välj ett annat";
            sakta(mes8, tid);
        }
        
    }while(!spelare.Contains(check));

    string mes7 = "Vem vill du fråga, spelare 2, 3 eller 4. Skriv 2, 3 eller 4";
    sakta(mes7, tid);


    frågavilkenspelare = int.Parse(Console.ReadLine());

    if(frågavilkenspelare == 2){
        DraKort_frånhand(ref breek, ref spelare, ref spelare2, check, ref frågavilkenspelare, ref spelare3, ref spelare4);
    }

    if(frågavilkenspelare == 3){
        DraKort_frånhand(ref breek, ref spelare, ref spelare3, check, ref frågavilkenspelare, ref spelare2, ref spelare4);
    }

    if(frågavilkenspelare == 4){
        DraKort_frånhand(ref breek, ref spelare, ref spelare4, check, ref frågavilkenspelare, ref spelare2, ref spelare3);
    }
}

static string DraKort(List<string> kortlek, Random r){
    int index = r.Next(kortlek.Count);         // Dra ett slumpmässigt index
    string kort = kortlek[index];           // Få kortet på det indexet
    kortlek.RemoveAt(index);                // Ta bort kortet från kortleken
    return kort;                            // Returnera kortet
}

static void DraKort_frånhand(ref int breek, ref List<string> spelare, ref List<string> andrahand, string check, ref int frågavilkenspelare, ref List<string> tredjespelare, ref List<string> fjärdespelare){
    int hurmånga = 1;
    int b = frågavilkenspelare;

    if(andrahand.Contains(check)){
        hurmånga = 0;
        do{
            andrahand.Remove(check);
            spelare.Add(check);
            hurmånga++;
        }while(andrahand.Contains(check));
        string mes1 = "spelare" + frågavilkenspelare + " Hade " + hurmånga + " " + check + "a";
        sakta(mes1, 50);

    }
    else{
        string mes2 = "spelare" + frågavilkenspelare + " Hade " + hurmånga + " " + check + "a";
        sakta(mes2, 50);
        b++;
        breek = 1;
    }

    if(frågavilkenspelare==b){
        string mes3 = "Du får välja igen";
        sakta(mes3, 50);
        duvillta(ref spelare, ref check, ref frågavilkenspelare, ref andrahand, ref tredjespelare, ref fjärdespelare);
        DraKort_frånhand(ref breek, ref spelare, ref andrahand, check, ref frågavilkenspelare, ref tredjespelare, ref fjärdespelare);
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
        Thread.Sleep(50);
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
