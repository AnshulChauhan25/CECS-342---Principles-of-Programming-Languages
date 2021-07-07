-- Derick Bui
-- Function that merges two lists into sorted list
merge :: Ord a => [a] -> [a] -> [a]
--merge takes 2 lists of type a which must have an order and outputs a list of type a
merge xs [] = xs -- edge case if right list is empty
merge [] ys = ys -- edge case if left list is empty
merge (x:xs) (y:ys) | x < y     = x:merge xs (y:ys)
                    | otherwise = y:merge (x:xs) ys

msort :: Ord a => [a] -> [a] -- merge sort a list in Haskell
--msort takes a list of type a with an order and outputs a list of type a
msort [] = []
msort [a] = [a]
-- msort recursively merges the msort of two halves
msort xs = merge (msort (firstHalf xs)) (msort (secondHalf xs))
  -- create a list that merges the two halves
  where firstHalf  xs = take (length xs `div` 2) xs -- create left half of the list by taking the left half (takes first half of the list)
        secondHalf xs = drop (length xs `div` 2) xs -- create right half of the list by dropping the left half (drops first half of the list)