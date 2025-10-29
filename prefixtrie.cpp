
#include <iostream>
using namespace std;

int main()
{
	struct trieNode {
		trieNode* childrens[26];
		bool isEnd;

		trieNode() {
			isEnd = false;
			for (int i = 0; i < 26; i++) {
				childrens[i] = nullptr;
			}

		}
	};

	class Trie {
		trieNode* root = new trieNode();

		int CharToInt(const char& c) {
			return c - 'a';
		}
	public:
		void Insert(const string& word) {
			trieNode* node = root;
			for (char c : word) {
				int index = CharToInt(c);
				if (node->childrens[index] == nullptr)
					node->childrens[index] = new trieNode();
				node = node->childrens[index];
			}
			node->isEnd = true;
		}
		bool Search(const string& word) {
			trieNode* node = root;
			for (char c : word) {
				int index = CharToInt(c);
				if (node->childrens[index] == nullptr) {
					return false;
				}
				node = node->childrens[index];
			}
			if (!node->isEnd)
				return false;
			return true;
		}
		
	};

	

	Trie a;
	a.Insert("kotek");
	
	cout<<
	a.Search("kot")<<
	a.Search("kotek");


}

