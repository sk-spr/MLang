# MLang
An esoteric programming language based on MLA8 citations.
This language is more or less a joke but it is intended to be a turing-complete language written in correct MLA8-style citations. Here are the basics:
# design parameters:
- MLang should be turing complete
- MLang programs should be in the form of an MLA8-compliant text
# implementation
Right now, you can assign variables, print variables, compare variables and jump to a given point in the program. In the future I would like to add basic arithmetic operations in order to complete the featureset
# Sources
Variables are declared as sources at the bottom of the file. They should be written in MLA8 style. The block of sources has to be preceded by the following line:

Sources:

Here, you list your sources. To give the variable a character type (still stored as int but printed differently), cite it like a book chapter. Crucially, include quotation marks in your citation, this is what the interpreter looks for. Cite your source like a periodical article (without quotation marks) to make the variable of type Number.
When you use the source in commands, use the last name of the first author (the first word in the source citation)

# Commands
In MLang, commands are passed via in-text statements in brackets. The interpreter ignores everything outside the bracket pairs so you can treat the text itself as optional window-dressing. There are a few basic commands (here, X takes the place of your source):

(X, 21) -- assign the value 21 to the variable X

(see X) -- print the value of X (either as a char or a number, depending on the type)

(Contrast X to Y) -- compare the values of X and Y and store the result in the internal bool T (greater than or equal->true)

(read Chapter N) -- if t is positive, jump to the instruction (Chapter N)

# Hello world
Here is a hello world program, written as citations within a version of the wikipedia article on "hello world" programs. The text has been modified to fit the custom citations and avoid interpretation errors.

(Chapter 1)

A "Hello, World!" program generally is a computer program that outputs or displays the message "Hello, World!". Such a program is very simple in most programming languages, and is often used to illustrate the basic syntax of a programming language. It is often the first program written by people learning to code.(Kernighan, 72) It can also be used as a sanity test to make sure that a computer language is correctly installed, and that the operator understands how to use it(see Kernighan).


"Hello, World!" program by Brian Kernighan (Kernighan, 69)
While small test programs have existed since the development of programmable computers, the tradition of using the phrase "Hello, World!" as a test message was influenced by an example program in the seminal 1978 book The C Programming Language.(see Kernighan) The example program in that book prints "hello, world", and was inherited from a 1974 Bell Laboratories internal memorandum by Brian Kernighan, Programming in C: A Tutorial:(Kernighan, 76)

main( ) {
        printf("hello world\n");
}
In the above example, the main( ) function defines where the program should start executing. The function body consists of a single statement, a call to the printf function, which stands for "print formatted". This function will cause the program to output whatever is passed to it as the parameter, in this case the string hello, world, followed by a newline character.

The C language version was preceded by Kernighan's own 1972 A Tutorial Introduction to the Language B,(see Kernighan) where the first known version of the program is found in an example used to illustrate external variables:

main( ) {
    extern a, b, c;
    putchar(a); putchar(b); putchar(c); putchar('!*n');
}
 
a 'hell';
b 'o, w';
c 'orld';
The program also prints hello, world! on the terminal, including a newline character. The phrase is divided into multiple variables because in B, a character constant is limited to four ASCII characters. The previous example in the tutorial printed hi! on the terminal, and the phrase hello, world! was introduced as a slightly longer greeting that required several character constants for its expression.

The Jargon File claims that "Hello, World!" originated instead with BCPL (1967).(Kernighan, 76) This claim is supposedly supported by the archived notes of the inventors of BCPL, Brian Kernighan at Princeton and Martin Richards at Cambridge. The phrase predated by over a decade its usage in computing; as early as the 1950s, it was the catchphrase of radio disc jockey William B. Williams.[7]

Variations

A "Hello, world!" program running on Sony's PlayStation Portable as a proof of concept
"Hello, World!" programs vary in complexity between different languages. In some languages, particularly scripting languages, the "Hello, World!" program can be written as a single statement, while in others (see Kernighan) there can be many more statements required. For example, in Python, to print the string Hello, World! followed by a newline, one need only write print("Hello World!"). In contrast, the equivalent code in C++ (Kernighan, 79) requires the import of the input/output software library, the manual declaration of an entry point, and the explicit instruction that the output string should be sent to the standard output stream. Generally, programming languages that give the programmer more control over the machine will result in more complex "Hello, World" programs.[8]

The phrase "Hello World!" has seen various deviations in punctuation and casing, such as the presence of the comma and exclamation mark, and the capitalization of the leading H and W. Some devices limit the format to specific variations, such as all-capitalized versions on systems that support only capital letters, while some esoteric programming languages may have to print a slightly modified string. For example, the first non-trivial Malbolge program printed "HEllO WORld", this having been determined to be good enough.(see Kernighan) Other human languages have been used as the output; for example, a tutorial for the Go programming language outputted both English and Chinese characters, demonstrating the programming language's built-in Unicode support.(Kernighan, 32)

Some languages change the functionality of the "Hello, World!" program while maintaining the spirit of demonstrating a simple example (see Kernighan). Functional programming languages, such as Lisp, ML and Haskell, tend to substitute a factorial program for "Hello, World!", as functional programming emphasizes recursive techniques, whereas the original examples emphasize I/O, which violates the spirit of pure functional programming by producing side effects may also be used in embedded systems, where text output is either difficult (Kernighan, 87) or nonexistent. For devices such as microcontrollers, field-programmable gate arrays, and CPLDs, "Hello, World!" may thus be substituted with a blinking LED, which demonstrates timing and interaction between components.(see Kernighan)

The Debian and Ubuntu Linux distributions provide the "Hello, World!" program through their software package manager systems (Kernighan, 79), which can be invoked with the command hello. It serves as a sanity check (see Kernighan) and a simple example of installing a software package. For developers, it provides an example of creating a .deb package, either traditionally or using debhelper, and the version of hello used, GNU Hello, serves as an example of writing a GNU program.(Kernighan, 82)

Variations of the "Hello, World!" program that produce a graphical output as opposed to text output have also been shown (see Kernighan). Sun demonstrated a "Hello, World!" program in Java based on scalable vector graphics,(Kernighan, 76) and the XL programming language features a spinning Earth "Hello, World!" using 3D computer graphics.(see Kernighan) Mark Guzdial and Elliot Soloway have suggested that the "hello, world" test message may be outdated now that graphics and sound can be manipulated as easily as text.(Kernighan, 68)

Time to Hello World

"Time to hello world" (TTHW) is the time it takes to author a "Hello, World!" program in a given programming language. This is one measure of a programming language's ease-of-use; since the program is meant as an introduction for people unfamiliar with the language, a more complex "Hello, World!" program may indicate that the programming language is less approachable.(see Kernighan) The concept has been extended beyond programming languages to APIs, as a measure of how simple it is for a new developer to get a basic example working; a faster time indicates an easier API for developers to adopt.

Sources:

Kernighan, Brian. "First Steps." The C Programming Language. Prentice Hall Inc, 1988



# output
the above program produces the output "HELLO WORLD" when executed
