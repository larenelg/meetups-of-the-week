from flask import Flask, request
import json
from extract_speaker import extract_names, extract_pronouns
app = Flask(__name__)

@app.route('/')
def hello_world():
    return 'Flask Dockerized'

@app.route('/extract-speaker', methods=['POST'])
def extract_speaker():
    error = None
    if request.method == 'POST':
        text = request.data
    else:
        error = 'invalid request'
        return error

    response = {};
    response["names"] = extract_names(text)
    response["pronouns"] = extract_pronouns(text)

    return json.dumps(response)

if __name__ == '__main__':
    app.run(debug=True,host='0.0.0.0')