function removeDublicates(str){
  // преобразуем в массив
  let arrOfWords = str.split(/\?|!|:|;|,|\.|\s|\t/);

  //находим повторяющиеся буквы (дубликаты) в словах
  for (let word of arrOfWords) {
    let tempArray = word.split('').sort();
    
    for (let i = 0; i < tempArray.length; i++) {
      if (tempArray[i + 1] === tempArray[i]) {
        let duplicate = tempArray[i];

        //удаляем дубликаты из строки
        newStr = str.replaceAll(duplicate, '');
      }
    }    
  }
  return newStr;

}
