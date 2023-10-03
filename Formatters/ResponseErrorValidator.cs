using FluentValidation.Results;

namespace appflow.Formatters;
public class ResponseErrorValidator
{
    public static Dictionary<string, string[]> createResponseObject(ValidationResult validationResult)
    {
        Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();

        foreach (ValidationFailure failure in validationResult.Errors)
        {

            string[] arr = null;

            List<string> list = new List<string>();

            arr = list.ToArray();

            if (dictionary.ContainsKey(failure.PropertyName))
            {
                List<string> listError = new List<string>();
                foreach (string error in dictionary[failure.PropertyName])
                {
                    listError.Add(error);
                }
                listError.Add(failure.ErrorMessage);

                dictionary[failure.PropertyName] = listError.ToArray();

            }
            else
            {
                List<string> listError = new List<string>{
                    failure.ErrorMessage
                };

                dictionary.Add(failure.PropertyName, listError.ToArray());
            }


        }
        return dictionary;
    }
}