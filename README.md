# NiquIoC
This is my own implementation of IoC (Inversion of Control) container.
To create new instance of object I am using Reflection.Emit.
I implemented two solutions:
- PartialEmitFunction - function takes constructor arguments as parameters, puts them onto the evaluation stack and uses to create desirable object;
it is faster, when you have small numbers of dependences and small number of resolve.
- FullEmitFunction - function doesn't take any arguments, it puts everything what is needed on evaluation stack and creates desirable object in the end;
it is faster, when you have huge numbers of dependences and huge number of resolve.
