# Fg42 Assembly

## Registers and variables
### Reserved registers
- `pin1`, `pin2`, `pin3`, etc.
- `mem`: working memory.

### Custom variables
- `var <name> <type>`

#### Data types
- `str`: string.
- `int`: signed integer.

## Instruction set
### Basic
- `mov dest source`: moves the source value to dest.
- `nop`: skips a cycle.
- `msg source`: prints the source value to console.

### Arithmetic
- `inc dest`: increments dest by 1.
- `dec dest`: decrements dest by 1.
- `add dest source`: adds source to dest and stores the result in `mem`.
- `sub dest source`: subtracts source from dest and stores the result in `mem`.
- `mul dest source`: multiplies source to dest and stores the result in `mem`.
- `div dest source`: divides source by dest and stores the result in `mem`.

### Conditions
- `cmp dest source`: compares source to dest and stores the result in the `mem` register (`0` for equal values, `1` for source > dest, `-1` for source < dest).
- `jmp dest`: jumps to dest label.
- `je dest`: jumps to dest label if `cmp` value is equal.
- `jne dest`: jumps to dest label if `cmp` value is not equal.
- `jg dest`: jumps to dest label if `cmp` value is greater.
- `jge dest`: jumps to dest label if `cmp` value is greater or equal.
- `jl dest`: jumps to dest label if `cmp` value is less.
- `jle dest`: jumps to dest label if `cmp` value is less or equal.

## Sample code
```
settings:
    mov pin1 1  // input
    mov pin1 1
    mov pin1 0  // output
    mov pin1 0

program:
```