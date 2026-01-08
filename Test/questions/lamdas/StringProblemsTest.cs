using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Samples.questions.lambdas;

namespace Test.questions.lamdas
{
    [TestFixture]
    public class StringProblemsTest
    {
        StringProblems stringProblems;

        [SetUp]
        public void Setup()
        {
            stringProblems = new StringProblems();
        }

        [Test]
        public void CleanStringShouldReturnNonSpecialCharacters() {
            // Arrange
            var input = "mama$";
            var expected = "mama";

            // Act
            var newResult =stringProblems.CleanString(input);
            
            // Assert 
            Assert.AreEqual(expected, newResult);
        }

        [Test]
        public void CleanStringShouldReturnNonSpecialCharactersAndSpaces()
        {
            // Arrange
            var input = "ma ma$";
            var expected = "mama";

            // Act
            var newResult = stringProblems.CleanString(input);

            // Assert 
            Assert.AreEqual(expected, newResult);
        }

        [Test]
        public void CountVowels_Return_Correct_Number()
        {
            // Arrange
            var input = "mama";
            var expected = 2;

            // Act
            var newResult = stringProblems.CountVowels(input);

            // Assert 
            Assert.AreEqual(expected, newResult);
        }

        [Test]
        public void CountVowelsApproachB_Return_Correct_Number()
        {
            // Arrange
            var expected = 3;
            var input = "Hello World";

            // Act
            var result = stringProblems.CountVowelsApprochB(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CountVowelsApproachA_Return_Correct_Number()
        {
            // Arrange
            var expected = 5;
            var input = "The quick brown fox";

            // Act
            var result = stringProblems.CountVowelsApprochB(input);

            // Assert
            Assert.AreEqual(expected, result);
        }


        [Test]
        public void CountVowels_Return_Correct_Number_ScenarioTwo()
        {
            // Arrange
            var input = "mamA se";
            var expected = 3;

            // Act
            var newResult = stringProblems.CountVowels(input);

            // Assert 
            Assert.AreEqual(expected, newResult);
        }

        [Test]
        public void ReverseWords_Return_Correct_Scenario()
        {
            // Arrange
            var input = "the sky is blue";
            var expected = "blue is sky the";

            // Act
            var newResult = stringProblems.ReverseWords(input);

            // Assert 
            Assert.AreEqual(expected, newResult);
        }

        [Test]
        public void ReverseWords_WithExtraSpaces_ShouldTrimSpaces()
        {
            // Arrange
            var input = "  hello world  ";
            var expected = "world hello";

            // Act
            var result = stringProblems.ReverseWords(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReverseWords_WithSingleWord_ShouldReturnSame()
        {
            // Arrange
            var input = "hello";
            var expected = "hello";

            // Act
            var result = stringProblems.ReverseWords(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        // ========================================================================
        // EXERCISE 3: FindMostFrequentChar Tests
        // ========================================================================
        [Test]
        public void FindMostFrequentChar_WithProgramming_ShouldReturnG()
        {
            // Arrange
            var input = "programming";
            var expected = 'g';

            // Act
            var result = stringProblems.FindMostFrequentChar(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FindMostFrequentChar_WithTie_ShouldReturnFirstAlphabetically()
        {
            // Arrange
            var input = "aabbcc";
            var expected = 'a';

            // Act
            var result = stringProblems.FindMostFrequentChar(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FindMostFrequentChar_WithSingleChar_ShouldReturnThatChar()
        {
            // Arrange
            var input = "aaaa";
            var expected = 'a';

            // Act
            var result = stringProblems.FindMostFrequentChar(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        // ========================================================================
        // EXERCISE 4: HasAllUniqueCharacters Tests
        // ========================================================================
        [Test]
        public void HasAllUniqueCharacters_WithUniqueChars_ShouldReturnTrue()
        {
            // Arrange
            var input = "abcdef";

            // Act
            var result = stringProblems.HasAllUniqueCharacters(input);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void HasAllUniqueCharacters_WithDuplicates_ShouldReturnFalse()
        {
            // Arrange
            var input = "hello";

            // Act
            var result = stringProblems.HasAllUniqueCharacters(input);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void HasAllUniqueCharacters_WithEmptyString_ShouldReturnTrue()
        {
            // Arrange
            var input = "";

            // Act
            var result = stringProblems.HasAllUniqueCharacters(input);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void HasAllUniqueCharacters_WithSingleChar_ShouldReturnTrue()
        {
            // Arrange
            var input = "a";

            // Act
            var result = stringProblems.HasAllUniqueCharacters(input);

            // Assert
            Assert.IsTrue(result);
        }

        // ========================================================================
        // EXERCISE 5: RemoveDuplicates Tests
        // ========================================================================
        [Test]
        public void RemoveDuplicates_WithProgramming_ShouldRemoveDuplicates()
        {
            // Arrange
            var input = "programming";
            var expected = "progamin";

            // Act
            var result = stringProblems.RemoveDuplicates(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void RemoveDuplicates_WithAabbcc_ShouldReturnAbc()
        {
            // Arrange
            var input = "aabbcc";
            var expected = "abc";

            // Act
            var result = stringProblems.RemoveDuplicates(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void RemoveDuplicates_WithAllUnique_ShouldReturnSame()
        {
            // Arrange
            var input = "abc";

            // Act
            var result = stringProblems.RemoveDuplicates(input);

            // Assert
            Assert.AreEqual(input, result);
        }

        [Test]
        public void RemoveDuplicates_WithEmptyString_ShouldReturnEmpty()
        {
            // Arrange
            var input = "";

            // Act
            var result = stringProblems.RemoveDuplicates(input);

            // Assert
            Assert.AreEqual("", result);
        }

        // ========================================================================
        // EXERCISE 6: GetCharacterFrequency Tests
        // ========================================================================
        [Test]
        public void GetCharacterFrequency_WithHello_ShouldReturnCorrectFrequency()
        {
            // Arrange
            var input = "hello";
            var expected = new Dictionary<char, int>
            {
                {'h', 1},
                {'e', 1},
                {'l', 2},
                {'o', 1}
            };

            // Act
            var result = stringProblems.GetCharacterFrequency(input);

            // Assert
            Assert.AreEqual(expected.Count, result.Count);
            foreach (var kvp in expected)
            {
                Assert.IsTrue(result.ContainsKey(kvp.Key));
                Assert.AreEqual(kvp.Value, result[kvp.Key]);
            }
        }

        [Test]
        public void GetCharacterFrequency_WithAabb_ShouldReturnCorrectFrequency()
        {
            // Arrange
            var input = "aabb";
            var expected = new Dictionary<char, int>
            {
                {'a', 2},
                {'b', 2}
            };

            // Act
            var result = stringProblems.GetCharacterFrequency(input);

            // Assert
            Assert.AreEqual(expected.Count, result.Count);
            foreach (var kvp in expected)
            {
                Assert.IsTrue(result.ContainsKey(kvp.Key));
                Assert.AreEqual(kvp.Value, result[kvp.Key]);
            }
        }

        [Test]
        public void GetCharacterFrequency_WithEmptyString_ShouldReturnEmptyDictionary()
        {
            // Arrange
            var input = "";

            // Act
            var result = stringProblems.GetCharacterFrequency(input);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        // ========================================================================
        // EXERCISE 7: CapitalizeWords Tests
        // ========================================================================
        [Test]
        public void CapitalizeWords_WithHelloWorld_ShouldCapitalizeFirstLetters()
        {
            // Arrange
            var input = "hello world";
            var expected = "Hello World";

            // Act
            var result = stringProblems.CapitalizeWords(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CapitalizeWords_WithMultipleSpaces_ShouldPreserveSpaces()
        {
            // Arrange
            var input = "  multiple   spaces  ";
            var expected = "  Multiple   Spaces  ";

            // Act
            var result = stringProblems.CapitalizeWords(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CapitalizeWords_WithSingleWord_ShouldCapitalizeFirstLetter()
        {
            // Arrange
            var input = "hello";
            var expected = "Hello";

            // Act
            var result = stringProblems.CapitalizeWords(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CapitalizeWords_WithAlreadyCapitalized_ShouldKeepCapitalized()
        {
            // Arrange
            var input = "Hello World";
            var expected = "Hello World";

            // Act
            var result = stringProblems.CapitalizeWords(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        // ========================================================================
        // EXERCISE 8: IsAnagram Tests
        // ========================================================================
        [Test]
        public void IsAnagram_WithListenAndSilent_ShouldReturnTrue()
        {
            // Arrange
            var str1 = "listen";
            var str2 = "silent";

            // Act
            var result = stringProblems.IsAnagram(str1, str2);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsAnagram_WithHelloAndWorld_ShouldReturnFalse()
        {
            // Arrange
            var str1 = "hello";
            var str2 = "world";

            // Act
            var result = stringProblems.IsAnagram(str1, str2);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsAnagram_WithMorseCode_ShouldReturnTrue()
        {
            // Arrange
            var str1 = "The Morse Code";
            var str2 = "Here come dots";

            // Act
            var result = stringProblems.IsAnagram(str1, str2);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsAnagram_WithDifferentCase_ShouldReturnTrue()
        {
            // Arrange
            var str1 = "Listen";
            var str2 = "silent";

            // Act
            var result = stringProblems.IsAnagram(str1, str2);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsAnagram_WithEmptyStrings_ShouldReturnTrue()
        {
            // Arrange
            var str1 = "";
            var str2 = "";

            // Act
            var result = stringProblems.IsAnagram(str1, str2);

            // Assert
            Assert.IsTrue(result);
        }

        // ========================================================================
        // EXERCISE 9: FindLongestWord Tests
        // ========================================================================
        [Test]
        public void FindLongestWord_WithMultipleWords_ShouldReturnLongest()
        {
            // Arrange
            var input = "programming is fun";
            var expected = "programming";

            // Act
            var result = stringProblems.FindLongestWord(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FindLongestWord_WithTie_ShouldReturnFirst()
        {
            // Arrange
            var input = "The quick brown fox jumps";
            // All of "quick", "brown", "jumps" have 5 chars, should return first

            // Act
            var result = stringProblems.FindLongestWord(input);

            // Assert
            Assert.IsTrue(result.Length == 5);
            Assert.IsTrue(result == "quick" || result == "brown" || result == "jumps");
        }

        [Test]
        public void FindLongestWord_WithSingleWord_ShouldReturnThatWord()
        {
            // Arrange
            var input = "hello";

            // Act
            var result = stringProblems.FindLongestWord(input);

            // Assert
            Assert.AreEqual("hello", result);
        }

        // ========================================================================
        // EXERCISE 10: RemoveOddIndexCharacters Tests
        // ========================================================================
        [Test]
        public void RemoveOddIndexCharacters_WithAbcdef_ShouldReturnAce()
        {
            // Arrange
            var input = "abcdef";
            var expected = "ace";

            // Act
            var result = stringProblems.RemoveOddIndexCharacters(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void RemoveOddIndexCharacters_WithHello_ShouldReturnHlo()
        {
            // Arrange
            var input = "Hello";
            var expected = "Hlo";

            // Act
            var result = stringProblems.RemoveOddIndexCharacters(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void RemoveOddIndexCharacters_WithSingleChar_ShouldReturnSame()
        {
            // Arrange
            var input = "H";

            // Act
            var result = stringProblems.RemoveOddIndexCharacters(input);

            // Assert
            Assert.AreEqual("H", result);
        }

        [Test]
        public void RemoveOddIndexCharacters_WithTwoChars_ShouldReturnFirst()
        {
            // Arrange
            var input = "Hi";
            var expected = "H";

            // Act
            var result = stringProblems.RemoveOddIndexCharacters(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        // ========================================================================
        // EXERCISE 11: GroupWordsByLength Tests
        // ========================================================================
        [Test]
        public void GroupWordsByLength_WithMultipleWords_ShouldGroupCorrectly()
        {
            // Arrange
            var input = "I am learning C# programming";
            var expected = new Dictionary<int, List<string>>
            {
                {1, new List<string> {"I"}},
                {2, new List<string> {"am", "C#"}},
                {8, new List<string> {"learning", "programming"}}
            };

            // Act
            var result = stringProblems.GroupWordsByLength(input);

            // Assert
            Assert.AreEqual(expected.Count, result.Count);
            foreach (var kvp in expected)
            {
                Assert.IsTrue(result.ContainsKey(kvp.Key));
                CollectionAssert.AreEquivalent(kvp.Value, result[kvp.Key]);
            }
        }

        [Test]
        public void GroupWordsByLength_WithSingleWord_ShouldGroupCorrectly()
        {
            // Arrange
            var input = "hello";
            var expected = new Dictionary<int, List<string>>
            {
                {5, new List<string> {"hello"}}
            };

            // Act
            var result = stringProblems.GroupWordsByLength(input);

            // Assert
            Assert.AreEqual(expected.Count, result.Count);
            Assert.IsTrue(result.ContainsKey(5));
            CollectionAssert.AreEquivalent(expected[5], result[5]);
        }

        // ========================================================================
        // EXERCISE 12: IsPalindromeIgnoreCaseAndSpecial Tests
        // ========================================================================
        [Test]
        public void IsPalindromeIgnoreCaseAndSpecial_WithValidPalindrome_ShouldReturnTrue()
        {
            // Arrange
            var input = "A man, a plan, a canal: Panama";

            // Act
            var result = stringProblems.IsPalindromeIgnoreCaseAndSpecial(input);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsPalindromeIgnoreCaseAndSpecial_WithInvalidPalindrome_ShouldReturnFalse()
        {
            // Arrange
            var input = "race a car";

            // Act
            var result = stringProblems.IsPalindromeIgnoreCaseAndSpecial(input);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsPalindromeIgnoreCaseAndSpecial_WithSimplePalindrome_ShouldReturnTrue()
        {
            // Arrange
            var input = "racecar";

            // Act
            var result = stringProblems.IsPalindromeIgnoreCaseAndSpecial(input);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsPalindromeIgnoreCaseAndSpecial_WithEmptyString_ShouldReturnTrue()
        {
            // Arrange
            var input = "";

            // Act
            var result = stringProblems.IsPalindromeIgnoreCaseAndSpecial(input);

            // Assert
            Assert.IsTrue(result);
        }

        // ========================================================================
        // EXERCISE 13: GetAllSubstrings Tests
        // ========================================================================
        [Test]
        public void GetAllSubstrings_WithHelloAndLength3_ShouldReturnCorrectSubstrings()
        {
            // Arrange
            var input = "hello";
            var length = 3;
            var expected = new List<string> { "hel", "ell", "llo" };

            // Act
            var result = stringProblems.GetAllSubstrings(input, length);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void GetAllSubstrings_WithAbcAndLength2_ShouldReturnAbAndBc()
        {
            // Arrange
            var input = "abc";
            var length = 2;
            var expected = new List<string> { "ab", "bc" };

            // Act
            var result = stringProblems.GetAllSubstrings(input, length);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void GetAllSubstrings_WithLengthEqualToInput_ShouldReturnSingleSubstring()
        {
            // Arrange
            var input = "hello";
            var length = 5;
            var expected = new List<string> { "hello" };

            // Act
            var result = stringProblems.GetAllSubstrings(input, length);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void GetAllSubstrings_WithLengthGreaterThanInput_ShouldReturnEmpty()
        {
            // Arrange
            var input = "abc";
            var length = 5;

            // Act
            var result = stringProblems.GetAllSubstrings(input, length);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        // ========================================================================
        // EXERCISE 14: SortByFrequency Tests
        // ========================================================================
        [Test]
        public void SortByFrequency_WithTree_ShouldSortByFrequency()
        {
            // Arrange
            var input = "tree";
            // e appears twice, t and r appear once
            // Result should have e's first, then t and r

            // Act
            var result = stringProblems.SortByFrequency(input);

            // Assert
            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(2, result.Count(c => c == 'e'));
            Assert.IsTrue(result.IndexOf('e') < result.IndexOf('t') || result.IndexOf('e') < result.IndexOf('r'));
        }

        [Test]
        public void SortByFrequency_WithCccaaa_ShouldSortByFrequency()
        {
            // Arrange
            var input = "cccaaa";
            // Both c and a appear 3 times

            // Act
            var result = stringProblems.SortByFrequency(input);

            // Assert
            Assert.AreEqual(6, result.Length);
            Assert.AreEqual(3, result.Count(c => c == 'c'));
            Assert.AreEqual(3, result.Count(c => c == 'a'));
        }

        [Test]
        public void SortByFrequency_WithAllSameChars_ShouldReturnSame()
        {
            // Arrange
            var input = "aaaa";

            // Act
            var result = stringProblems.SortByFrequency(input);

            // Assert
            Assert.AreEqual("aaaa", result);
        }

        // ========================================================================
        // EXERCISE 15: ReplaceCharacter Tests
        // ========================================================================
        [Test]
        public void ReplaceCharacter_WithHelloWorld_ShouldReplaceLWithX()
        {
            // Arrange
            var input = "hello world";
            var oldChar = 'l';
            var newChar = 'x';
            var expected = "hexxo worxd";

            // Act
            var result = stringProblems.ReplaceCharacter(input, oldChar, newChar);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReplaceCharacter_WithNoMatches_ShouldReturnSame()
        {
            // Arrange
            var input = "hello";
            var oldChar = 'z';
            var newChar = 'x';

            // Act
            var result = stringProblems.ReplaceCharacter(input, oldChar, newChar);

            // Assert
            Assert.AreEqual(input, result);
        }

        [Test]
        public void ReplaceCharacter_WithAllMatches_ShouldReplaceAll()
        {
            // Arrange
            var input = "aaaa";
            var oldChar = 'a';
            var newChar = 'b';
            var expected = "bbbb";

            // Act
            var result = stringProblems.ReplaceCharacter(input, oldChar, newChar);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReplaceCharacter_WithEmptyString_ShouldReturnEmpty()
        {
            // Arrange
            var input = "";
            var oldChar = 'a';
            var newChar = 'b';

            // Act
            var result = stringProblems.ReplaceCharacter(input, oldChar, newChar);

            // Assert
            Assert.AreEqual("", result);
        }

        // ========================================================================
        // Additional Edge Case Tests for CleanString
        // ========================================================================
        [Test]
        public void CleanString_WithNumbers_ShouldKeepNumbers()
        {
            // Arrange
            var input = "Hello123World";
            var expected = "Hello123World";

            // Act
            var result = stringProblems.CleanString(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CleanString_WithOnlySpecialChars_ShouldReturnEmpty()
        {
            // Arrange
            var input = "!@#$%";
            var expected = "";

            // Act
            var result = stringProblems.CleanString(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CleanString_WithEmptyString_ShouldReturnEmpty()
        {
            // Arrange
            var input = "";
            var expected = "";

            // Act
            var result = stringProblems.CleanString(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        // ========================================================================
        // Additional Edge Case Tests for CountVowels
        // ========================================================================
        [Test]
        public void CountVowels_WithNoVowels_ShouldReturnZero()
        {
            // Arrange
            var input = "bcdfg";
            var expected = 0;

            // Act
            var result = stringProblems.CountVowels(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CountVowels_WithAllVowels_ShouldReturnCount()
        {
            // Arrange
            var input = "aeiou";
            var expected = 5;

            // Act
            var result = stringProblems.CountVowels(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CountVowels_WithEmptyString_ShouldReturnZero()
        {
            // Arrange
            var input = "";
            var expected = 0;

            // Act
            var result = stringProblems.CountVowels(input);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
