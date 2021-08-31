function CalcStr() {

  let str = document.getElementById("string").value;

  str.replace(/\s/g, '');

  let arrStr = str.split('');

  if (arrStr.pop() !== '=') {
    throw new Error("Отсутствует знак \"=\" ");
  }

  console.log('before splite', JSON.stringify(arrStr));

  let i = 1;

  while (arrStr.length > 2) {
    arrStr[0] = parseFloat(arrStr[0]);
    arrStr[2] = parseFloat(arrStr[2]);
    switch (arrStr[1]) {
      case '+':
        arrStr.splice(0, 3, arrStr[0] + arrStr[2]);
        break;
      case '-':
        arrStr.splice(0, 3, arrStr[0] - arrStr[2]);
        break;
      case '*':
        arrStr.splice(0, 3, arrStr[0] * arrStr[2]);
        break;
      case '/':
        arrStr.splice(0, 3, arrStr[0] / arrStr[2]);
        break;

      default:
        alert('Неверный формат строки');
        return;
    }

    console.log(`iteration ${i++}`, JSON.stringify(arrStr));
  }

  console.log('result', JSON.stringify(arrStr), arrStr[0].toFixed(2));

  document.getElementById("result").innerHTML = arrStr[0].toFixed(2);
}