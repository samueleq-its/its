using System;
using System.Collections.Generic;
using System.Linq;

namespace GestioneAtleti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var atleti = new List<Atleta>
            {
                new Atleta { Cognome = "Rossi", Nome = "Luca", DataNascita = new DateTime(2010, 5, 12), Disciplina = "100m", NumeroPettorina = 11, Sesso = "M" },
                new Atleta { Cognome = "Bianchi", Nome = "Sara", DataNascita = new DateTime(2008, 9, 2), Disciplina = "Lungo", NumeroPettorina = 12, Sesso = "F" },
                new Atleta { Cognome = "Verdi", Nome = "Marco", DataNascita = new DateTime(2004, 2, 20), Disciplina = "1500m", NumeroPettorina = 23, Sesso = "M" },
                new Atleta { Cognome = "Esposito", Nome = "Giulia", DataNascita = new DateTime(1999, 11, 15), Disciplina = "Alto", NumeroPettorina = 7, Sesso = "F" },
                new Atleta { Cognome = "Ferrari", Nome = "Andrea", DataNascita = new DateTime(1988, 7, 1), Disciplina = "100m", NumeroPettorina = 5, Sesso = "M" },
                new Atleta { Cognome = "Romano", Nome = "Elena", DataNascita = new DateTime(1984, 3, 28), Disciplina = "Peso", NumeroPettorina = 19, Sesso = "F" },
                new Atleta { Cognome = "Gallo", Nome = "Davide", DataNascita = new DateTime(1977, 6, 9), Disciplina = "Marcia", NumeroPettorina = 31, Sesso = "M" },
                new Atleta { Cognome = "Costa", Nome = "Marta", DataNascita = new DateTime(1972, 1, 4), Disciplina = "Lungo", NumeroPettorina = 42, Sesso = "F" },
                new Atleta { Cognome = "Conti", Nome = "Paolo", DataNascita = new DateTime(1968, 10, 21), Disciplina = "800m", NumeroPettorina = 44, Sesso = "M" },
                new Atleta { Cognome = "Rinaldi", Nome = "Anna", DataNascita = new DateTime(1961, 12, 30), Disciplina = "Alto", NumeroPettorina = 8, Sesso = "F" },
                new Atleta { Cognome = "Greco", Nome = "Simone", DataNascita = new DateTime(1955, 8, 18), Disciplina = "Peso", NumeroPettorina = 16, Sesso = "M" },
                new Atleta { Cognome = "Lombardi", Nome = "Francesca", DataNascita = new DateTime(1950, 4, 7), Disciplina = "Giavellotto", NumeroPettorina = 27, Sesso = "F" },
                new Atleta { Cognome = "Moretti", Nome = "Stefano", DataNascita = new DateTime(1943, 2, 14), Disciplina = "100m", NumeroPettorina = 2, Sesso = "M" },
                new Atleta { Cognome = "Barbieri", Nome = "Chiara", DataNascita = new DateTime(1938, 5, 25), Disciplina = "Marcia", NumeroPettorina = 55, Sesso = "F" },
                new Atleta { Cognome = "Fontana", Nome = "Alessio", DataNascita = new DateTime(1932, 9, 11), Disciplina = "Lungo", NumeroPettorina = 61, Sesso = "M" },
                new Atleta { Cognome = "Mariani", Nome = "Patrizia", DataNascita = new DateTime(1928, 6, 19), Disciplina = "Alto", NumeroPettorina = 70, Sesso = "F" },
                new Atleta { Cognome = "Ferri", Nome = "Nicola", DataNascita = new DateTime(2013, 1, 30), Disciplina = "60m", NumeroPettorina = 3, Sesso = "M" },
                new Atleta { Cognome = "Sanna", Nome = "Noemi", DataNascita = new DateTime(2006, 8, 4), Disciplina = "200m", NumeroPettorina = 14, Sesso = "F" },
                new Atleta { Cognome = "Villa", Nome = "Tommaso", DataNascita = new DateTime(1995, 10, 16), Disciplina = "400m", NumeroPettorina = 18, Sesso = "M" },
                new Atleta { Cognome = "De Luca", Nome = "Alessia", DataNascita = new DateTime(1980, 11, 6), Disciplina = "Peso", NumeroPettorina = 29, Sesso = "F" }
            };

            Console.WriteLine("ELENCO COMPLETO DEGLI ATLETI");
            foreach (var atleta in atleti)
            {
                StampaAtleta(atleta);
            }

            Console.WriteLine();
            Console.WriteLine("ELENCO DEGLI ATLETI RAGGRUPPATI PER DISCIPLINA");
            foreach (var gruppo in atleti.GroupBy(a => a.Disciplina).OrderBy(g => g.Key))
            {
                Console.WriteLine($"Disciplina: {gruppo.Key}");
                foreach (var atleta in gruppo)
                {
                    StampaAtleta(atleta);
                }
            }

            Console.WriteLine();
            Console.WriteLine("ELENCO DEGLI ATLETI RAGGRUPPATI PER CATEGORIA");
            foreach (var gruppo in atleti.GroupBy(a => a.CalcolaCategoria()).OrderBy(g => g.Key))
            {
                Console.WriteLine($"Categoria: {gruppo.Key}");
                foreach (var atleta in gruppo)
                {
                    StampaAtleta(atleta);
                }
            }
        }

        private static void StampaAtleta(Atleta atleta)
        {
            Console.WriteLine($"{atleta.Cognome} {atleta.Nome} - Nato/a il {atleta.DataNascita:dd/MM/yyyy} - Età: {atleta.CalcolaEta()} - Categoria: {atleta.CalcolaCategoria()} - Disciplina: {atleta.Disciplina} - Pettorina: {atleta.NumeroPettorina} - Sesso: {atleta.Sesso}");
        }
    }
}
