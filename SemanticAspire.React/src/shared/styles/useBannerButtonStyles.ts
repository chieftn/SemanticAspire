import { shorthands, createCustomFocusIndicatorStyle, makeStyles, tokens } from '@fluentui/react-components';

export const useBannerButtonStyles = makeStyles({
    focusIndicator: createCustomFocusIndicatorStyle({
        outlineColor: tokens.colorNeutralBackground1,
        outlineOffset: '-2px',
        boxShadow: '0px 0px 0px 0px',
        borderRadius: '0px',
    }),
    bannerButton: {
        ':hover': {
            backgroundColor: tokens.colorBrandBackgroundHover,
            color: tokens.colorNeutralBackground1,
            ...shorthands.borderColor('transparent'),
        },
        ':hover:active': {
            backgroundColor: tokens.colorBrandBackgroundPressed,
            color: tokens.colorNeutralBackground1,
            ...shorthands.borderColor('transparent'),
        },
        backgroundColor: tokens.colorBrandBackground,
        color: tokens.colorNeutralBackground1,
        minWidth: '48px',
        ...shorthands.borderColor('transparent'),
        ...shorthands.borderRadius('0'),
    },
});
