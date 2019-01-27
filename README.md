# Scapegoat-tree
Sorting method

INTRODUCTION:
A scapegoat Tree is a self-balancing binary search tree. Binary Search tree can become unbalanced after insertions and deletions. It starts fixing the problem by identifying the scapegoat node which caused the unbalanced tree, a partial rebuilding operation can be performed. This operation takes the entire sub-tree where the scapegoat is located and deconstructs and rebuilds it into a perfectly balanced sub-tree. The trees guarantee the amortized complexity of Insert and Delete O(log n) time while the worst case complexity of Searchingis O(log n) time where n is the number of nodes in the tree. It is the first kind of balanced binary search trees that do not store extra information at every node while still maintaining
the complexity as above. The values kept track are the number of nodes in the tree and the
maximum number of nodes since the trees were last rebuilt. The name of the trees comes
from that rebuilding the tree only is taken place only after detection of a special node called
Scapegoat, whose rooted subtree is not weight-balanced.
Definition of a scapegoat node is :A node S is  called scapegoat node if a newly inserted deep node N if S is an sncestor of N and S is not α-weight-balanced.
Alpha:The alpha for a scapegoat tree can be any number between 0.5 and 1.
NOTATIONS OF SCAPEGOAT TREE:
Following are some notations that we used in our implementation:
• n.left      refers to the left child of n
• n.right    refers to the right child of n
• height() refers to the height of the subtree rooted at n or the longest distance in terms
                of edges from n to some leaf.
•n.parent refers to the parent node of node n.
• n.size() is the procedure to compute the size of the binary search tree rooted at node.
•n.data  refers to the value of node

OPERATIONS ON SCAPEGOAT TREES
Now we will explain how to do Search, Insert, Delete operations work on a Scapegoat tree.
Search Operation:
Search operation in scapegoat tree is done same as binary search tree.
Example for  Searching for deleting any node: 
 
 


Insertion:
The insert in scapegoat tree is also done like regular Insert Operation is Binary Search Tree When Treee is still height-balanced . when T is not height-balanced then a scapegoat node will be detected and rebuilding will be take place at the subtree rooted at scapegoat node.
To insert value e in a tree we create a new node n and insert e using binary search tree insert algorithm assuming α = 2/3 . If height  is greater than log32(height) then we’ll call Find- scapegoat function. 
 

Find Scapegoat:
The procedure findscapegoat tree implemented in the following will return the scapegoat node after the scapegoat node is detected if applicable the function rebuilt-tree () will get called . Rebuilt-Tree will rebuilt a new ½-weight-balanced subtree rooted at scapegoat node. In this operation we walkup until we reach a node n with (3*Size(n)<=2*Size*(n.parent)) this node is scapegoat and we rebuild the subtree rooted at scapegoat node.  Assuming  α = 2/3

 

Delete:
Deleting a node in a scapegoat tree is done by first deleting the node in a regular binary search tree then if applicable finding a scapegoat node then rebuilt a new ½-weight-balanced subtree rooted at scapegoat node.
 


Rebuild function:
In this operation we simply convert the subtree to the most possible balanced binary search tree. 
 
The procedure Build  Balanced Tree(array,index, size) will build a 1/2-weight-balanced
tree from the Array of all the nodes in a binary search tree . The procedure will return
the last node of the Array. Now, the procedure Rebuild Tree( scapegoat) just
makes use of packIntoArray(scapegoat,array, index) procedure to flatten the subtree rooted at scapegoat. and Build  Balanced Tree((array,index, size) to rebuild the Array into 1/2-weight-
balanced binary search tree T. Because the call Build Balanced Tree((array,index, size)
will return the last node of the array so in order to retrieve the root of the 1/2-weight-
balanced tree then just traverse the parents of node head until we reach the root and this
could be done in O(log (T.size)) time because T is 1/2-weight-balanced then T is also 1/2-
height-balanced.

Why we use scapegoat tree?
We use scapegoat tree to balance binary search tree in most possible way.


Advantage:
Scapegoat tree can achieve its complexity without storing extra information at every node this saves large amount of space.

Disadvantage:
Lazy data structure only does work when search paths get too long.
