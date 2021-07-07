--quicksort.hs
  --Anshul Chauhan
  --016246735
  --Thank you

qsort2 :: Ord a => [a] -> [a]                                         --here, this is the main  required function for quicksort 

qsort2 [] = []                                                        -- Base condition quicksort will brings out an empty list. if        empty list is provided 
-- A sorted list has sublist on the left of the pivot which chose the the first element of the list as pivot
--Where all elements on the left is less than or equal to the           pivot and it has a sublist on the right of the pivot where all        elements on the right sublist is greater than the pivot. And to       combine both values you just concatenate to the pivot which we filter all the elements that are less than pivot to smallSorted and  greater than pivot to bigSorted.

qsort2 (x:xs) = smallSorted ++ [x] ++ bigSorted
  where smallSorted = qsort2 (filter (<=x) xs)
        bigSorted   = qsort2 (filter (>x) xs)
  --filter p [] = []
  --filter p (x:xs) = 
  --if p x then x : filter p xs and else filter p is xs


arr = [4, 65, 2, -31, 0, 99, 2, 83, 287, 1]
