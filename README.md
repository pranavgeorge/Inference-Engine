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
  
Research
=============================================================================================================

Output:
------------------------------------------------------------------------------------------------------------


Acknowledgements/Resources: 
=============================================================================================================


Notes: 
=============================================================================================================

Summary report:
=============================================================================================================
Total task:
1. Truth Table
2. Forward Chaining
3. Backwards Chaining
4. Research
5. Documentation
