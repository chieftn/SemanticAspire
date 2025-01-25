import typescriptEslint from '@typescript-eslint/eslint-plugin';
import unicornEslint from 'eslint-plugin-unicorn';
import jsDocEslint from 'eslint-plugin-jsdoc';
import reactEslint from 'eslint-plugin-react';
import importEslint from 'eslint-plugin-import';
import tsParser from '@typescript-eslint/parser';
import eslintConfigPrettier from 'eslint-config-prettier';

export default [
    {
        files: ['**/*.ts'],
    },
    {
        languageOptions: {
            parser: tsParser,
            parserOptions: {
              ecmaFeatures: {
                modules: true
              },
              ecmaVersion: 'latest',
              project: './tsconfig.json',
            },
        },

        plugins: {
            '@typescript-eslint': typescriptEslint,
            'unicorn': unicornEslint,
            'react': reactEslint,
            'jsdoc': jsDocEslint,
            'import': importEslint
        },

        rules: {
            '@typescript-eslint/adjacent-overload-signatures': 'error',
            '@typescript-eslint/array-type': [
                'error',
                {
                    default: 'array-simple',
                },
            ],
            '@typescript-eslint/consistent-type-assertions': 'error',
            '@typescript-eslint/consistent-type-definitions': 'error',
            '@typescript-eslint/dot-notation': 'error',
            '@typescript-eslint/explicit-member-accessibility': [
                'error',
                {
                    accessibility: 'explicit',
                },
            ],
            '@typescript-eslint/naming-convention': [
                'error',
                {
                    selector: 'variable',
                    format: ['camelCase', 'UPPER_CASE', 'PascalCase'],
                    leadingUnderscore: 'forbid',
                    trailingUnderscore: 'forbid',
                },
            ],
            '@typescript-eslint/no-empty-function': 'error',
            '@typescript-eslint/no-empty-interface': 'error',
            '@typescript-eslint/no-explicit-any': 'error',
            '@typescript-eslint/no-for-in-array': 'error',
            '@typescript-eslint/no-magic-numbers': ['error', { ignoreEnums: true, ignore: [-1, 0, 1] }],
            '@typescript-eslint/no-misused-new': 'error',
            '@typescript-eslint/no-namespace': 'error',
            '@typescript-eslint/no-parameter-properties': 'off',
            '@typescript-eslint/no-restricted-types': 'error',
            '@typescript-eslint/no-shadow': [
                'error',
                {
                    hoist: 'all',
                },
            ],
            '@typescript-eslint/no-this-alias': 'error',
            '@typescript-eslint/no-unused-expressions': 'error',
            '@typescript-eslint/no-use-before-define': 'off',
            '@typescript-eslint/no-var-requires': 'error',
            '@typescript-eslint/prefer-for-of': 'error',
            '@typescript-eslint/prefer-function-type': 'error',
            '@typescript-eslint/prefer-namespace-keyword': 'error',
            '@typescript-eslint/triple-slash-reference': [
                'error',
                {
                    path: 'always',
                    types: 'prefer-import',
                    lib: 'always',
                },
            ],
            '@typescript-eslint/typedef': [
                'error',
                {
                    parameter: true,
                    propertyDeclaration: true,
                },
            ],
            '@typescript-eslint/unified-signatures': 'error',
            'comma-dangle': 'off',
            complexity: 'off',
            'constructor-super': 'error',
            curly: 'error',
            'default-case': 'error',
            'dot-notation': 'off',
            eqeqeq: ['error', 'always'],
            'guard-for-in': 'error',
            'id-denylist': [
                'error',
                'any',
                'Number',
                'number',
                'String',
                'string',
                'Boolean',
                'boolean',
                'Undefined',
                'undefined',
            ],
            'id-match': 'error',
            'import/no-extraneous-dependencies': 'error',
            'import/no-internal-modules': [
                'error',
                {
                    allow: [
                        '@fluentui/**/*',
                        '@microsoft/**/*',
                    ],
                },
            ],
            'import/order': [
                'error',
                {
                    'newlines-between': 'never',
                    groups: [
                        ['builtin', 'external', 'internal', 'unknown', 'object', 'type'],
                        'parent',
                        ['sibling', 'index'],
                    ],
                    distinctGroup: false,
                    pathGroupsExcludedImportTypes: [],
                    pathGroups: [
                        {
                            pattern: './',
                            patternOptions: {
                                nocomment: true,
                                dot: true,
                            },
                            group: 'sibling',
                            position: 'before',
                        },
                        {
                            pattern: '.',
                            patternOptions: {
                                nocomment: true,
                                dot: true,
                            },
                            group: 'sibling',
                            position: 'before',
                        },
                        {
                            pattern: '..',
                            patternOptions: {
                                nocomment: true,
                                dot: true,
                            },
                            group: 'parent',
                            position: 'before',
                        },
                        {
                            pattern: '../',
                            patternOptions: {
                                nocomment: true,
                                dot: true,
                            },
                            group: 'parent',
                            position: 'before',
                        },
                    ],
                },
            ],
            indent: 'off',
            'jsdoc/check-alignment': 'error',
            'jsdoc/check-indentation': 'error',
            'jsdoc/tag-lines': ['error', 'any', {startLines: 1}],
            'max-classes-per-file': ['error', 1],
            'no-bitwise': 'error',
            'no-caller': 'error',
            'no-cond-assign': 'error',
            'no-console': 'error',
            'no-debugger': 'error',
            'no-duplicate-case': 'error',
            'no-duplicate-imports': 'error',
            'no-empty': 'error',
            'no-empty-function': 'off',
            'no-eval': 'error',
            'no-extra-bind': 'error',
            'no-fallthrough': 'error',
            'no-invalid-this': 'error',
            'no-magic-numbers': 'off',
            'no-new-func': 'error',
            'no-new-wrappers': 'error',
            'no-param-reassign': 'error',
            'no-redeclare': 'error',
            'no-return-await': 'error',
            'no-sequences': 'error',
            'no-shadow': 'off',
            'no-sparse-arrays': 'error',
            'no-template-curly-in-string': 'error',
            'no-throw-literal': 'error',
            'no-undef-init': 'error',
            'no-underscore-dangle': 'error',
            'no-unsafe-finally': 'error',
            'no-unused-expressions': 'off',
            'no-unused-labels': 'error',
            'no-use-before-define': 'off',
            'no-var': 'error',
            'object-shorthand': 'error',
            'one-var': ['error', 'never'],
            'prefer-const': 'error',
            'prefer-object-spread': 'error',
            quotes: 'off',
            radix: 'error',
            'react/jsx-boolean-value': ['error', 'always'],
            'react/jsx-key': 'error',
            'react/self-closing-comp': 'error',
            semi: 'off',
            'space-in-parens': ['off', 'never'],
            'spaced-comment': [
                'error',
                'always',
                {
                    markers: ['/'],
                },
            ],
            'unicorn/filename-case': ['error', { cases: { camelCase: true, pascalCase: true } }],
            'unicorn/prefer-ternary': 'error',
            'use-isnan': 'error',
            'valid-typeof': 'off',
        }
    },
    eslintConfigPrettier, // eslint-config-prettier last
];
