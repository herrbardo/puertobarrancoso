-> main

=== main ===
    ¿Qué bicho te gusta?
    + [Charmander]
        -> chosen("Charmander")
    + [Pikachu]
        -> chosen("Pikachu")
        
=== chosen(pokemon) ===
Tu bicho es {pokemon}
-> clima

=== clima ===
    ¿Qué onda el clima?
    * Soleado
        Posta?
            * * Se...
            * * No pelotudo
        - - Ah ok...
    * Frío
    * Unabergah
- Un gusto hablar con vos
-> suma

VAR numeroA = 0
VAR numeroB = 0

=== suma ===
    {numeroA > 0 && numeroB > 0:
        La suma es: {sumar(numeroA, numeroB)}
        ->END
    }

    Elegite un número
    * 5
        {numeroA==0:
            ~numeroA = 5
        - else:
            ~numeroB = 5
        }
        ->suma
    * 4
        {numeroA==0:
            ~numeroA = 4
        - else:
            ~numeroB = 4
        }
        ->suma
    * 7
        {numeroA==0:
            ~numeroA = 7
        - else:
            ~numeroB = 7
        }
        ->suma
- Forro
-> END

=== function sumar(a, b) ===
~ return a + b

        