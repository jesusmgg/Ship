#OldScript

Indentation levels indicates blocks.  
`int`s are used as booleans, a value of `0` is false, every other value is true.  

## Keywords
- `<type> <name>`
- `<type> <name> = <value>`
- `def <name>:`
- `def <name>(<type> <arg1>, <type> <arg2>):`
- `return <value>`
- `if <condition>:`
- `else:`
- `while <condition>:`
- `continue`
- `break`
- `print <value>`
- `// comment`
- `or`
- `and`
- `not`
- `==`
- `!=`

## Types
- `int`: signed integer
- `string`: string


## Code sample
```
settings:
    pins:
        pin0 = 1  // input
        pin1 = 1
        pin2 = 0  // output
        pin3 = 0

program:
    while pin0:
        if not pin1:
            pin2 = 1
            pin3 = 25
        else:
            pin2 = 0
            pin3 = 0
```