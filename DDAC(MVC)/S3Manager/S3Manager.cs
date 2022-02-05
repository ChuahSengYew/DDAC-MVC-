using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDAC_MVC.S3Manager
{
    public class S3Manager
    {
        private const string bucketName = "elasticbeanstalk-us-east-1-788946909279";
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast1;

        private static IAmazonS3 client;
        public static string accesskey;
        public static string secretkey;

        public void Main()
        {
            var accesskey = "ASIA3PMHGPBP555BHRWI";
            var secretkey = "EpCIfK37CSvfzKNtE6KmC28kqkHpDo3WJYk9EQsa";
            var token = "FwoGZXIvYXdzEHgaDPLGfmp/zzMJVv+iQSLJAaAG31WxkcA/jD5/krfRpiGwGhD+yOW1YfDrD/NSgNEAyO15dNLWv9i5m+Q/nSRuFcLMZiKxyMW1DZB2u6DBYDHKVCOSBTaDynMJxKcJG1pX9ADH/n/9PkcngDNzKmwOj81eqJPNCdMYYdyR+PlJiRXk6c3qkwwMCMhK11DVqKkZ3cUdPOFoG2TB5xptOHc0xL2HU4vXQUEjtef23fX4VZ3Ez2lkex3uaynwead8/jrHIg8PwwpLYAbf1RVSverDf+7iNyQxnRwO3SifsPiPBjIt+VymdOweNZxKnZbwzAn70z//VN1OdvpoLQGMMB9RbXjAR0yrxT3AThEgfIYl";

            client = new AmazonS3Client(accesskey, secretkey, token,bucketRegion);
        }

        //Uploading image
        public async Task WritingAnObjectAsync([FromForm] IFormFile file, String keyName1, String foldername)
        {
            try
            {
                var putRequest1 = new PutObjectRequest
                {
                    BucketName = bucketName + "/" + foldername,
                    Key = keyName1,
                    InputStream = file.OpenReadStream(),
                    ContentType = file.ContentType,
                     CannedACL = S3CannedACL.PublicRead

                };

                PutObjectResponse response1 = await client.PutObjectAsync(putRequest1);

            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine(
                        "Error encountered ***. Message:'{0}' when writing an object"
                        , e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    "Unknown encountered on server. Message:'{0}' when writing an object"
                    , e.Message);
            }
        }

        //Deleting image
        public async Task DeleteObjectNonVersionedBucketAsync(String keyName)
        {
            try
            {
               
                    
                    var deleteObjectRequest = new DeleteObjectRequest
                    {
                        BucketName = bucketName + "/images",
                        Key = keyName
                    };

                    await client.DeleteObjectAsync(deleteObjectRequest);

                    var deleteObjectRequest1 = new DeleteObjectRequest
                    {
                        BucketName = bucketName + "/musics",
                        Key = keyName
                    };

                    await client.DeleteObjectAsync(deleteObjectRequest1);



            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when deleting an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when deleting an object", e.Message);
            }
        }
    }
}
