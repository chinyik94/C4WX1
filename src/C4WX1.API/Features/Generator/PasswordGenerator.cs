using C4WX1.API.Features.SysConfig.Constants;
using C4WX1.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace C4WX1.API.Features.Generator
{
    public class PasswordGenerator(
        THCC_C4WDEVContext dbContext): IPasswordGenerator
    {
        public async Task<string> GenerateAsync()
        {
            var now = DateTime.Now;
            var seed = now.Year + now.Month + now.Day + now.Hour + now.Second + now.Millisecond;
            var rnd = new Random(seed);

            var passwordSysConfigs = await dbContext.SysConfig
                .Where(x => x.ConfigName == SysConfigNames.MinLength
                    || x.ConfigName == SysConfigNames.MaxLength
                    || x.ConfigName == SysConfigNames.PasswordNumberLength
                    || x.ConfigName == SysConfigNames.PasswordUpperLength
                    || x.ConfigName == SysConfigNames.PasswordSpecialLength
                    || x.ConfigName == SysConfigNames.PasswordSpecialCharacters)
                .ToListAsync();

            var minLength = !int.TryParse(passwordSysConfigs.First(x => x.ConfigName == SysConfigNames.MinLength).ConfigValue, out int parsedMinLength)
                ? 8
                : parsedMinLength;

            var maxLength = !int.TryParse(passwordSysConfigs.First(x => x.ConfigName == SysConfigNames.MaxLength).ConfigValue, out int parsedMaxLength)
                ? 16
                : parsedMaxLength;

            var numberLength = !int.TryParse(passwordSysConfigs.First(x => x.ConfigName == SysConfigNames.PasswordNumberLength).ConfigValue, out int parsedNumberLength)
                ? 1
                : parsedNumberLength;

            var upperLength = !int.TryParse(passwordSysConfigs.First(x => x.ConfigName == SysConfigNames.PasswordUpperLength).ConfigValue, out int parsedUpperLength)
                ? 1
                : parsedUpperLength;

            var specialLength = !int.TryParse(passwordSysConfigs.First(x => x.ConfigName == SysConfigNames.PasswordSpecialLength).ConfigValue, out int parsedSpecialLength)
                ? 1
                : parsedSpecialLength;

            var specialCharacters = passwordSysConfigs.First(x => x.ConfigName == SysConfigNames.PasswordSpecialCharacters).ConfigValue;

            var totalCharacters = rnd.Next(minLength, maxLength);
            totalCharacters = Math.Min(totalCharacters, 8);

            var password = new StringBuilder();

            for (int i = 0; i < totalCharacters; i++)
            {
                int selectType;
                do
                {
                    selectType = rnd.Next(0, 4);

                    // Check if we can add this type of character
                    if (selectType == 0)  // Lowercase
                    {
                        if ((numberLength + upperLength + specialLength) ==
                            (totalCharacters - password.Length))
                            continue;
                    }
                    else if (selectType == 1 && numberLength == 0)  // Numbers
                        continue;
                    else if (selectType == 2 && upperLength == 0)    // Uppercase
                        continue;
                    else if (selectType == 3 && specialLength == 0)  // Special
                        continue;

                    // Update remaining counts
                    switch (selectType)
                    {
                        case 1:
                            numberLength--;
                            break;
                        case 2:
                            upperLength--;
                            break;
                        case 3:
                            specialLength--;
                            break;
                    }

                    break;
                } while (true);

                switch (selectType)
                {
                    case 0:  // Lowercase
                        password.Append((char)rnd.Next(97, 123));
                        break;
                    case 1:  // Numbers
                        password.Append(rnd.Next(0, 10));
                        break;
                    case 2:  // Uppercase
                        password.Append((char)rnd.Next(65, 91));
                        break;
                    case 3:  // Special
                        if (string.IsNullOrEmpty(specialCharacters))
                            break;
                        int specialCharIndex = rnd.Next(0, specialCharacters.Length);
                        password.Append(specialCharacters[specialCharIndex]);
                        break;
                }
            }

            return password.ToString();
        }
    }
}
