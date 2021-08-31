function remover(){

    let str = document.getElementById("string").value;

    let arrOfWords = str.split(/\?|!|:|;|,|\.|\s|\t/);

    for (let word of arrOfWords) {
        let tempArray = word.split('').sort();
        
        for (let i = 0; i < tempArray.length; i++) {
          if (tempArray[i + 1] === tempArray[i]) {
            let duplicate = tempArray[i];

            str = str.replaceAll(duplicate, '');
          }
        }    
      }

    document.getElementById("result").innerHTML = str;
}