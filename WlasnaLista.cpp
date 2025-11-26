

#include <iostream>
using namespace std;


struct Node{

    int value;
    Node* nextNode;
    Node* previousNode;

    public: 

    Node(int value) {
        this->value = value;
        nextNode = nullptr;
        previousNode = nullptr;
    }
};

class ListW {
    Node* selected;
    Node* root;

    public:
        ListW() {
            root = nullptr;
            selected = nullptr;
        }
        int Get(int index) {
            SelectByIndex(index);
            return selected->value;
        }
        void Insert(int index,int value) {
            SelectByIndex(index);
            Node* newNode = new Node(value);

            newNode->nextNode = selected->nextNode;
            newNode->previousNode = selected;


            if (selected->nextNode != nullptr)
                selected->nextNode->previousNode = newNode;

            selected->nextNode = newNode;

        }
        void PushFront(int value) {
            Node* newNode = new Node(value);

            newNode->nextNode = root;
            if (root != nullptr)
                root->previousNode = newNode;

            root = newNode;
            selected = newNode;
        }
        void PushBack(int value) {

            SelectLastElement();
            Node* newNode = new Node(value);

            if (root == nullptr) {
                root = newNode;
                selected = newNode;
                return;
            }

            newNode->previousNode = selected;
            selected->nextNode = newNode;

        }
    private:
        void SelectByIndex(int index) {

            if (root == nullptr) {
                cout << "Index out of range error" << endl;
                return;
            }
            
            selected = root;


            for (int i = 0;i < index;i++) {
                selected = selected->nextNode;
            }

            if (selected == nullptr)
                cout << "Index out of range error" << endl;
        }

        void SelectLastElement() {
            if (root == nullptr)
                return;
            selected = root;

            while (selected->nextNode != nullptr) {
                selected = selected->nextNode;
            }
        }

};


int main()
{ 
    ListW lista;
    lista.PushBack(2);
    lista.PushBack(1);
    lista.PushBack(3);
    lista.PushBack(3);

    cout << lista.Get(3);

    return 0;
}
