const request = require('supertest');
const authRequest = request('https://testauth.infotrack.com.au');
const apiRequest = request('http://localhost:4010');

// This piece of code is for getting the authorization token after login to your app.
let token;
beforeAll((done) => {
    authRequest.post(`/connect/token`)
        .auth('a6b580b1-f56d-46a6-84e4-38c0cdb5e919z', 'mhfeY6kaZw8It596x6rmhQeak+6C+AP+')
        .send('grant_type=password')
        .send(`username=globalteamau`)
        .send(`password=pass4global`)
        .send(`scope=openid profile infsec:basic infsec:identity`)
        .send('response_type=id_token')
        .end((err, response) => {
            token = response.body.access_token  //to save the login token for further requests
            done();
    });
});

describe("GET Todo Items List", () => {
    try {
        test("Get list with valid request succeeds", async done =>{
            apiRequest.get(`/items`)
                .set('Authorization', `Bearer ${token}`) //Authorization token
                .expect(200)
                .then((res) => {
                    expect(res.body).toBeDefined();
                    done();
                });
        });

        test("Get fails without authorisation", async done =>  {
            apiRequest.get(`/items`)
                .expect(401)
                .then(() => {
                    done();
                });
        });
    }
    catch(err){
        console.log("Exception : ", err)
      }
});