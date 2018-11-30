# source: https://medium.com/@acrosson/extracting-names-emails-and-phone-numbers-5d576354baa

import re
import nltk
nltk.download('stopwords')
nltk.download('punkt')
nltk.download('averaged_perceptron_tagger')
nltk.download('maxent_ne_chunker')
nltk.download('words')
# from nltk.corpus import stopwords
# stop = stopwords.words('english')

def ie_preprocess(document):
    # document = ' '.join([i for i in document.split() if i not in stop])
    sentences = nltk.sent_tokenize(document)
    sentences = [nltk.word_tokenize(sent) for sent in sentences]
    sentences = [nltk.pos_tag(sent) for sent in sentences]
    return sentences

def extract_names(document):
    names = []
    sentences = ie_preprocess(document)
    for tagged_sentence in sentences:
        for chunk in nltk.ne_chunk(tagged_sentence):
            if type(chunk) == nltk.tree.Tree:
                if chunk.label() == 'PERSON':
                    names.append(' '.join([c[0] for c in chunk]))
    return names

def extract_pronouns(document):
    pronouns = []
    sentences = ie_preprocess(document)
    for tagged_sentence in sentences:
        for chunk in nltk.ne_chunk(tagged_sentence):
            if type(chunk) == tuple:
                if (chunk[1] == 'PRP'):
                    if ((chunk[0] == 'she') | (chunk[0] == 'She') | (chunk[0] == 'he') | (chunk[0] == 'He') | (chunk[0] == 'they') | (chunk[0] == 'They')):
                        pronouns.append(chunk[0])
    return pronouns

