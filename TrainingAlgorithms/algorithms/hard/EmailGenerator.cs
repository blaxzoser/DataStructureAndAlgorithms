using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace TrainingAlgorithms.algorithms.hard
{
    // ============================================================================
    // EMAIL GENERATOR (interview-style string problem)
    // ============================================================================
    // Builds on the frequency count exercises (FirstUniqueCharacter, ValidAnagram,
    // RansomNote): a Dictionary counts how many times each email was already
    // given out, and that count becomes the number at the end of the email.
    // The new part: parsing a messy string (split, trim, clean) before counting.
    //
    // Total practice time: ~1 hour
    // ============================================================================
    public class EmailGenerator
    {
        // ========================================================================
        // SAMPLE 1: Give every person a company email
        // ========================================================================
        // 'names' holds full names separated by ','. Each name is
        // "First [Middle ...] Last". Return every person as
        // "Full Name <email@company.com>", joined by ", " (comma + space),
        // in the same order as the input.
        //
        // Rules:
        //   1. Email = first letter of the FIRST name, lower case
        //      + the LAST name (only its letters, as written).
        //      "Luis Pintado" -> lPintado
        //      "Ana Garcia-Lopez" -> aGarciaLopez, "Shaquille O'Neal" -> sONeal
        //      A one-word name uses the whole word in lower case: "Cher" -> cher
        //   2. Middle names are ignored in the email, but the output keeps the
        //      full name: "Peter Benjamin Parker <pParker@marvel.com>"
        //   3. Repeated emails get a number at the end: the 2nd one gets 2,
        //      the 3rd one gets 3, and so on. Compare IGNORING case
        //      (cher and cHer are the same email).
        //      lPintado, lPintado2, lPintado3
        //   4. Company domain: lower case, only letters and digits.
        //      "Acme Corp" -> acmecorp.com
        //   5. Clean the full name: trim it and keep ONE space between words.
        //      Skip empty entries ("a b,,c d" has 2 people, not 3).
        //      null or "" -> ""
        //
        // ("Luis Pintado, Laura Pintado, Lucas Pintado", "example")
        //   -> "Luis Pintado <lPintado@example.com>, Laura Pintado <lPintado2@example.com>,
        //       Lucas Pintado <lPintado3@example.com>"
        // ("Peter Benjamin Parker, Peter Parker", "Marvel")
        //   -> "Peter Benjamin Parker <pParker@marvel.com>, Peter Parker <pParker2@marvel.com>"
        // ("Cher, Carl Her", "music")          -> "Cher <cher@music.com>, Carl Her <cHer2@music.com>"
        // ("  Luis   Pintado ,, ", "example")  -> "Luis Pintado <lPintado@example.com>"
        // ("", "example") or (null, "example") -> ""
        //
        //   name             email base    seen before?   email
        //   "Luis Pintado"   lPintado      0 times        lPintado
        //   "Laura Pintado"  lPintado      1 time         lPintado2
        //   "Lucas Pintado"  lPintado      2 times        lPintado3
        //
        // Difficulty: Hard
        // Goal: Time O(n) (n = length of 'names'), Space O(n)
        // Expected time to solve: 30 min
        // Pattern: Frequency count with a Dictionary (builds on FirstUniqueCharacter /
        //          ValidAnagram) + string parsing (split, trim, keep only letters)
        // Topic: Strings + Hashing
        // ========================================================================
        public string Generate(string names, string company)
        {

            if (string.IsNullOrEmpty(names))
                return string.Empty;

 
                var prefixDiccionary = new Dictionary<string, int>();
                var formatNames = names.Split(new char[] { ',' })
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .Select(fullnames => {


                var cleanFullNames = fullnames.Trim();
                var firstNameLastName = cleanFullNames.Split(new char[] { ' ',}, StringSplitOptions.RemoveEmptyEntries);


                var newFormat = string.Empty;
                if (firstNameLastName.Length == 2)
                    newFormat = $"{firstNameLastName[0][0].ToString().ToLower()}{string.Concat(firstNameLastName[1].Where(char.IsLetter))}";
                else if (firstNameLastName.Length == 3)
                    newFormat = $"{firstNameLastName[0][0].ToString().ToLower()}{firstNameLastName[2]}";
                else if (firstNameLastName.Length == 1)
                    newFormat = $"{string.Concat(firstNameLastName[0].Select(char.ToLower))}";

                if (!prefixDiccionary.ContainsKey(newFormat.ToLower()))
                {
                    prefixDiccionary[newFormat.ToLower()] = 0;
                }
                else
                {
                    prefixDiccionary[newFormat.ToLower()] = prefixDiccionary[newFormat.ToLower()] + 1;
                }

                var calculatePrefix = prefixDiccionary[newFormat.ToLower()] == 0 ? string.Empty : (prefixDiccionary[newFormat.ToLower()] + 1).ToString();
                var domain = string.Concat(company.Where(char.IsLetterOrDigit).Select(char.ToLower));
                var formatWithPrefix = $"<{newFormat}{calculatePrefix}@{domain}.com>";

                    if (firstNameLastName.Length == 1)
                        return $"{firstNameLastName[0]} {formatWithPrefix}";
                    else if (firstNameLastName.Length == 2)
                        return $"{firstNameLastName[0]} {firstNameLastName[1]} {formatWithPrefix}";
                    else
                        return $"{firstNameLastName[0]} {firstNameLastName[1]} {firstNameLastName[2]} {formatWithPrefix}";

                }).ToList();

            return string.Join(", ", formatNames);
        }

        // ========================================================================
        // REFERENCE SOLUTION (clean version of Generate, to compare later)
        // Same tests, same result. Differences with the first version:
        //   - Work with 'words' (the split name) for everything: no branch per size.
        //   - Skip empty entries with 'continue' (no null in the output).
        //   - Domain computed ONCE, outside the loop.
        //   - Case-insensitive Dictionary + TryGetValue (one lookup, no ToLower()).
        //   - Plain foreach: easier to read and debug than Select with side effects.
        // Time O(n), Space O(n)  (n = length of 'names')
        // ========================================================================
        public string Sample1Refactor(string names, string company)
        {
            // 8. null, "" (or only spaces) -> ""
            if (string.IsNullOrWhiteSpace(names))
                return string.Empty;

            // 4. Domain: same for everybody -> compute once.
            //    Keep letters/digits only, then lower case. (company ?? "") avoids a crash on null.
            var domain = string.Concat((company ?? string.Empty)
                .Where(char.IsLetterOrDigit)
                .Select(char.ToLower));

            // 3. How many times each email base was already given out.
            //    OrdinalIgnoreCase: "cher" and "cHer" are the same key.
            var timesSeen = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            var people = new List<string>();

            foreach (var entry in names.Split(','))
            {
                // 5. Split on spaces and drop empties: this trims AND collapses the spaces.
                //    "  Luis   Pintado " -> ["Luis", "Pintado"]
                var words = entry.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // Empty entry (",," or a trailing ","): skip it. No null, no empty slot in the Join.
                if (words.Length == 0)
                    continue;

                // 1. First name = first word. Last name = LAST word (middle names are ignored),
                //    keeping only its letters: "O'Neal" -> "ONeal", "Garcia-Lopez" -> "GarciaLopez".
                var firstName = words[0];
                var lastName = string.Concat(words[words.Length - 1].Where(char.IsLetter));

                // One word ("Cher") -> the whole word in lower case.
                // Otherwise -> first letter (lower case) + last name: "Luis Pintado" -> "lPintado".
                var emailBase = words.Length == 1
                    ? firstName.ToLower()
                    : char.ToLower(firstName[0]) + lastName;

                // 3. Counter: TryGetValue gives 0 when the key is missing, so
                //    "times seen before" + 1 = this person's position (1st, 2nd, 3rd...).
                timesSeen.TryGetValue(emailBase, out var count);
                count++;
                timesSeen[emailBase] = count;

                // 1st one has no number, from the 2nd one on: 2, 3, ...
                var number = count == 1 ? string.Empty : count.ToString();

                // The output keeps the full name (with middle names), cleaned.
                people.Add($"{string.Join(" ", words)} <{emailBase}{number}@{domain}.com>");
            }

            return string.Join(", ", people);
        }
    }
}
