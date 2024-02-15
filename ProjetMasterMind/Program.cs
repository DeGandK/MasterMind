//Déroulement du jeu
//1. L’application génère une liste de 5 chiffres (de 0 à 9) de manière aléatoire et affiche 5
//zones vides.
//2. Cinq « TextBox » permettent à l’utilisateur d’encoder les chiffres pour chaque zone.
//3. Lors de chaque essai de l’utilisateur :
//A) Il vérifie chaque chiffre pour la zone correspondante. Lorsqu’un chiffre est
//correct, celui-ci apparaît dans sa zone.
//B) Il affiche dans l’historique, le numéro de l’essai ainsi que les valeurs encodées.
//4. Une fois les 5 valeurs trouvées, il affiche le score (nombre d’essai) et un bouton pour
//recommencer.


//Initialiser un random
Random aleatoire = new Random();

// Initialiser le tableau du master
int[] Sequence = new int[5];

// Remplissage du tableau avec des valeurs aléatoires
for (int i = 0; i < Sequence.Length; i++)
    {
        Sequence[i] = aleatoire.Next(1, 10); // Génère un nombre aléatoire entre 1 et 9 inclus
    }

int Vies = 20;

while (Vies > 0)

{
    Console.WriteLine($"Il vous reste {Vies} vie(s)");
    Vies--;
    int [] Reponse = PropositionUtilisateur();

    // Vérifier la proposition de l'utilisateur et afficher les pions noirs et blancs
    int pionsNoirs = 0;
    int pionsBlancs = 0;
    bool[] indicesVerifies = new bool[Sequence.Length];


        for (int i = 0; i < Sequence.Length; i++)
        {
            if (Sequence[i] == Reponse[i])
            {
                pionsNoirs++;
                indicesVerifies[i] = true; // Marquer cet indice comme vérifié
            }
        }
    
    // Vérifier les pions blancs
    for (int i = 0; i < Reponse.Length; i++)
    {
        if (!indicesVerifies[i])
        {
            for (int j = 0; j < Sequence.Length; j++)
            {
                if (Reponse[i] == Sequence[j] && !indicesVerifies[j])
                {
                    pionsBlancs++;
                    indicesVerifies[j] = true; // Marquer cet indice comme vérifié
                    break;
                }
            }
        }
    }
    Console.WriteLine("----------------");
    Console.WriteLine($"Vous avez {pionsNoirs} bonne(s) réponse(s) bien placée(s) ");
    Console.WriteLine("----------------");
    Console.WriteLine($"Vous avez {pionsBlancs} bonne(s) réponse(s) mal placée(s)");
    Console.WriteLine("----------------");

    // Vérifier si l'utilisateur a trouvé la bonne séquence
    if (pionsNoirs == Sequence.Length)
    {
        Console.WriteLine("Bravo, c'est gagné");
        break;
    }
}

// Mort de l'utilisateur 

if ( Vies ==0)
{
    Console.WriteLine("Perduuuuuuuuuu");
    AfficherSequence(Sequence);
}

// Afficher la solution
static void AfficherSequence(int[] Sequence)
{
    foreach (int i in Sequence)
    {
        Console.WriteLine(i);
    }
}

// Création d'une fonction pour demander à l'utilisateur de rentrer sa proposition de séquence
static int[]  PropositionUtilisateur()
{
    int[] Proposition = new int[5];

    for (int i = 0;i < Proposition.Length;i++)
    {
        Console.WriteLine($"Veuillez entrer la valeur {i+1}");
        Proposition[i] = int.Parse(Console.ReadLine());
    }

    return Proposition;
}
