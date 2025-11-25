PriorityQueue priorityQueue = new PriorityQueue();

while (true)
{
    priorityQueue.Show();

    Console.WriteLine("Wybierz operacje : ");
    Console.WriteLine("1. Dodaj element");
    Console.WriteLine("2. Zdejmij");
    int action = Convert.ToInt32(Console.ReadLine());

    if(action == 0)
        break;
    
    switch (action)
    {
        case 1:
            {
                Console.Write("Podaj priorytet : ");

                int priority = Convert.ToInt32(Console.ReadLine());

                Console.Write("Podaj wartość : ");
                string value = Console.ReadLine();

                priorityQueue.Insert(priority, value);
                break;
            }
        case 2:
            {
                priorityQueue.Remove();
                break;
            }
    }
    Console.Clear();
}
class PriorityQueue 
{
    List <Element> queue;

    public PriorityQueue()
    {
        queue = new List <Element>();
    }
    public void Show()
    {
        if (queue.Count == 0)
        {
            Console.WriteLine("[ Kolejka jest pusta ]");
            return;
        }

        Console.WriteLine("=== Zawartość kolejki (kopiec max) ===");

        for (int i = 0; i < queue.Count; i++)
        {
            Console.WriteLine($"{i,2}:  priorytet = {queue[i].priority},  wartość = {queue[i].value}");
        }
        Console.WriteLine("======================================");
    }
    public void Insert(int priority,string value)
    {
        Element element = new Element(priority,value);
        queue.Add(element);
        HeapyfyUp(queue.Count - 1);
        
    }
    public void Remove()
    {
        if (queue.Count == 0)
            return;

        queue[0]=queue[queue.Count-1];
        queue.RemoveAt(queue.Count-1);

        HeapifyDown(0);
    }
    void HeapifyDown(int current)
    {
        while (true)
        {
            int leftChildIndex = 2 * current + 1;
            int rightChildIndex = 2 * current + 2;

            if (leftChildIndex >= queue.Count)
                break;

            int largestIndex = leftChildIndex;

            if (rightChildIndex < queue.Count &&
                queue[rightChildIndex].priority > queue[leftChildIndex].priority)
            {
                largestIndex = rightChildIndex;
            }

            if (queue[current].priority >= queue[largestIndex].priority)
                break;

            Element temp = queue[current];
            queue[current] = queue[largestIndex];
            queue[largestIndex] = temp;

            current = largestIndex;
        }
    }
    void HeapyfyUp(int current)
    {
        while(current > 0)
        {
            int parent = (current - 1) / 2;

            if (queue[parent].priority > queue[current].priority)
                break ;
            

            Element pom = queue[parent];
            queue[parent] = queue[current];
            queue[current] = pom;
            current = parent;
        }
    }
    struct Element
    {
        public int priority;
        public string value;

        public Element(int priority, string value)
        {
            this.priority = priority;
            this.value = value;
        }
    }
}

