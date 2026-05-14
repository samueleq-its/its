
main :: IO()
main = do
    file <- readFile "./txt/romeo-full.txt"
    print file