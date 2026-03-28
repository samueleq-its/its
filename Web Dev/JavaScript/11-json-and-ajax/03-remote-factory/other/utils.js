function test(fn, input, expected){
    let result = fn(input);
    console.log(`EXPECTED: ${expected}, OUTPUT: ${result}, PASSED:${expected == result}`);
}