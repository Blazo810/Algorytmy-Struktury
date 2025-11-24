using System.Runtime.InteropServices.Marshalling;

Console.WriteLine("Rozmiar : ");
int Tsize = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Przedzial dolny : ");
int downRange = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Przedzial górny : ");
int upRange = Convert.ToInt32(Console.ReadLine());
//Kod napisany jako bardziej notatka dla Rudego :)
int[] T = new int[Tsize];
Random rnd = new Random();

void FillArray()
{
    for (int i = 0; i < Tsize; i++)
    {
        T[i] = rnd.Next(downRange,upRange);
    }
}
void ShowArray()
{
    for (int i = 0; i < Tsize; i++)
    {
        Console.Write( T[i] + " ");
    }
}
//Podstawowe zależności na kopcu
//Rodzic = (i-1)/2 za okrąglone w dół (domyślnie)
//Dziecko lewe = 2i + 1 
//Dziecko prawe = 2i + 2
//Ostatni rodzic = n/2 + 1 n = długość tablicy

void Swap(int[] array, int i, int j)
{
    int temp = array[i];
    array[i] = array[j];
    array[j] = temp;
}
void HeapSort(){

    for (int i = T.Length / 2 - 1; i >= 0; i--)
        OrderMaxHeap(T,i,T.Length);

    //Za każdym razem zamieniamy roota z ostatnim branym pod uwage elementem
    for (int i = T.Length - 1; i >= 0; i--)
    {
        // Przenosimy root (max) na koniec
        int temp = T[0];
        T[0] = T[i];
        T[i] = temp;

        //Porządkujemy spowrotem 
        OrderMaxHeap( T, 0,i);
    }
}

//O wiele łatwiej tą funkcje napisać rekurencją ale ja chciałem wydajnie... Żałuje
void OrderMaxHeap(int[] T,int rootIndex,int heapSize){
    //Ta funkcja porządkuje dzieci z rootem 
    int largest = rootIndex;
    int pom = largest;

    while (true)
    {
        int left = 2 * largest + 1;
        int right = 2 * largest + 2;
        
        //Jeśli dziecko lewe jest większe od roota i istnieje to zamienia
        if(left < heapSize && T[left] > T[pom])
        {
            pom = left;
        }
        //to samo tylko z prawym
        if(right < heapSize && T[right] > T[pom])
        {
            pom = right;
        }

        //Jeśli już nic się nie smienia to zwracamy 
        if(largest == pom) 
            break;

        Swap(T, largest, pom);
        largest = pom;

    }
}


FillArray();
Console.WriteLine();
HeapSort();
ShowArray();
