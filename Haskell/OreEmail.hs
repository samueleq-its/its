import Data.List (isPrefixOf, sort, group)
-- leggi file, conta distribuzione email in base all'ora di invio
-- stampa riga per riga coppia ora - numero email ( es: 12 01)
-- FORMATO: "From stephen.marquard@uct.ac.za Sat Jan  5 09:14:16 2008"

main :: IO()
main = do
    file <- readFile "./txt/mbox.txt"
    let filteredLines = filter ("From " `isPrefixOf`) (lines file)
    let getHours line = takeWhile (/= ':') (words line !! 5)
    let hours = map getHours filteredLines
    let mailPerHours = map (\xs -> (head xs, length xs)) (group (sort hours))
    
    print mailPerHours
    putStrLn "END"