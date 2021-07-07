  --TYPE ":l main" ON CONSOLE FOR IT TO WORK
  
--CECS 342 Assignment 1 
-- Derick Bui
-- Function that merges two lists into sorted list
merge :: Ord a => [a] -> [a] -> [a]
merge xs [] = xs -- edge case if right list is empty
merge [] ys = ys -- edge case if left list is empty
merge (x:xs) (y:ys) | x < y     = x:merge xs (y:ys)
                    | otherwise = y:merge (x:xs) ys

msort :: Ord a => [a] -> [a] -- merge sort a list in Haskell
msort [] = [] -- Base condition if list is empty
msort [a] = [a] -- If list is single element
-- msort recursively merges the msort of two halves
msort xs = merge (msort (firstHalf xs)) (msort (secondHalf xs))
  -- create a list that merges the two halves
  -- create left half of the list by taking the left half (takes first half of the list)
  where firstHalf  xs = take (length xs `div` 2) xs 
  -- create right half of the list by dropping the left half (drops first half of the list)
        secondHalf xs = drop (length xs `div` 2) xs 

-------------------------------------------------------------------------------------------------

  --quicksort.hs
  --Anshul Chauhan
  --016246735
  --Thank you

qsort2 :: Ord a => [a] -> [a]                                         --here, this is the main  required function for quicksort 

qsort2 [] = []                                                        -- Base condition quicksort will brings out an empty list. if        empty list is provided 
-- A sorted list has sublist on the left of the pivot which chosen as    the first element.    
-- Where all elements on the left is less than or equal to the           pivot and it has a sublist on the right of the pivot where all        elements on the right sublist is greater than the pivot. And to       combine both values you just add or concatenate to the pivot which    will filter all the elements that are less than pivot to              smallSorted and  greater than pivot to bigSorted.

qsort2 (x:xs) = smallSorted ++ [x] ++ bigSorted

  where smallSorted = qsort2 (filter (<=x) xs)
        bigSorted   = qsort2 (filter (>x) xs)
  --filter p [] = []
  --filter p (x:xs) = 
  --if p x then x : filter p xs and else filter p is xs


arr = [4, 65, 2, -31, 0, 99, 2, 83, 287, 1]

-------------------------------------------------------------------------------------------------

data Gender = Female | Male deriving (Show, Eq)

isMale :: Gender -> Bool
isMale Male = True
isMale _    = False

isFemale g = case g of
                Female     -> True
                otherwise  -> False

data Person = Person String Int Gender deriving (Show, Eq)

name :: Person -> String
name   (Person n a g) = n

age :: Person -> Int
age    (Person n a g) = a 

gender :: Person -> Gender
gender (Person n a g) = g


-- Declare an order on persons (by name)
instance Ord Person where
  p <= q = name p <= name q

-- A list of some people
somePeople = [Person "Alice" 19 Female, Person "Bob" 20 Male, Person "Carol" 17 Female, Person "Dave" 30 Male]