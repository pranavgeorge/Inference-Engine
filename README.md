# Inference-Engine

Inference engine for propositional logic on the Truth Table (TT) checking, and Backward Chaining (BC) and Forward Chaining (FC) algorithms

Student Details:
-------------------------------------------------------------------------------------------------------------
- Pranav Gupta 	101335790


Features / Bugs / Missings
=============================================================================================================
- **Truth Table**:
    - Missing: only works with '&' and '=>' Conjunction
    - Bugs: None known.
    - Features: You can ask it a negation using "~". (eg. ~a)
    
- **Forward Chaining**:
    - Missing: only works with '&' and '=>' Conjunction
    - Bugs: None known.
    
- **Backwards Chaining**:
    - Missing: only works with '&' and '=>' Conjunction
    - Bugs: None known.
    
Test cases: 
=============================================================================================================
  - **test1.txt**:
  TELL
  p2=> p3; p3 => p1; c => e; b&e => f; f&g => h; p1=>d; p1&p3 => c; a; b; p2;
  ASK
  d
  
  - **test2.txt**:
  TELL
  p1&p2&p3=> p4; p5&p6 => p4; p1 => p2; p1&p2 => p3; p5&p7 => p6; p1; p4;
  ASK
  p7
  
  - **test3.txt**:
  TELL
  a=>b; c&d=>e; g&c=>a; f&a=>d; f&g=>c;f;g;
  ASK
  d
  
  - **test4.txt**:
  TELL
  learn =>coding; practise & coding => experience;experience => professional;learn;practise;
  ASK
  professional
  
  
Acknowledgements/Resources: 
=============================================================================================================
I took the content from the book Artificial Intelligence A Modern Approach Third Edition to understand the concept of Forward Chaining, Backward chaining and Truth Table.
I also went through the following lecture notes: 
- Lecture 6 Logical Agents & Knowledge Representation
- Lecture 7 Propositional Logic



Notes: 
=============================================================================================================

Summary report:
=============================================================================================================
Total task:
1. Truth Table: truth table for all given variables, checks whether KB is true and counts how many times KB|=alpha.
2. Forward Chaining: it determines if the single proposition symbol the query(q) is entailed by a knowledge base for the definite clauses. It begins with the known facts which are already true in the knowledge base. If all the premises of an implication is known then its conclusion is added to the known facts. The process is continued until the query(q) is added to the known facts or until no inference can be made.

3. Backwards Chaining: it works backward from the query. if the query is known to be true, then no need to perform further. Otherwise, the algorithm finds those implications in the knowledge base whose conclusion is q. If all the premises of one of those implications can be proved true (by backward chaining), then q is true. It works back down the graph until it reaches a set of known facts
