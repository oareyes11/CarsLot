namespace Core.Tools.ExternalRest
{
    public class ExternalRestPostImpl
    {

        public async void PostAsync(string url, Dictionary<string, string> headers, FormUrlEncodedContent content)
        {
            HttpClient? client = new HttpClient();

            HttpRequestMessage? request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
                Content = content
            };

            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
        }

    }
}