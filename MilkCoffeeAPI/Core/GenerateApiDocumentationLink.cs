//using Microsoft.AspNetCore.Mvc;

//namespace MilkCoffeeAPI.Core
//{
//    public class GenerateApiDocumentationLink
//    {
//        [HttpGet("apidocs")]
//        public IActionResult GetApiDocumentationLink()
//        {
//            // Generate the API documentation link dynamically
//            string documentationLink = GenerateApiDocumentationLink();

//            // Return the documentation link as a response
//            return Ok(documentationLink);
//        }

//        private string GenerateApiDocumentationLink()
//        {
//            // Retrieve the base URL of your backend API
//            string baseUrl = "http://example.com";

//            // Construct the Swagger UI endpoint based on your Swagger configuration
//            string swaggerUiEndpoint = "/swagger/index.html";

//            // Combine the base URL and Swagger UI endpoint to form the documentation link
//            string documentationLink = $"{baseUrl}{swaggerUiEndpoint}";

//            return documentationLink;
//        }
//    }
//}
