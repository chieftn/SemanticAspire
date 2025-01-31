import * as React from 'react';
import { PreviewLink20Filled, PreviewLink20Regular, bundleIcon } from '@fluentui/react-icons';
import { makeStyles } from '@fluentui/react-components';
import { NavDrawer, NavDrawerBody, NavItem, type OnNavItemSelectData } from '@fluentui/react-nav-preview';
import { useLocation, useNavigate } from '@tanstack/react-router';

const PerformanceReviews = bundleIcon(PreviewLink20Filled, PreviewLink20Regular);

const useStyles = makeStyles({
    rootStyle: {
        height: '100%',
    },
});

export const Navigation: React.FC = () => {
    const { rootStyle } = useStyles();
    const { pathname } = useLocation();
    const navigate = useNavigate();

    const onSelect = (ev: Event | React.SyntheticEvent<Element, Event>, data: OnNavItemSelectData) => {
        navigate({ to: data.value });
    };

    return (
        <div className={rootStyle}>
            <NavDrawer
                selectedValue={pathname}
                open={true}
                type="inline"
                onNavItemSelect={onSelect}
                className={rootStyle}
            >
                <NavDrawerBody>
                    <NavItem icon={<PerformanceReviews />} value="/">
                        Home
                    </NavItem>
                    <NavItem icon={<PerformanceReviews />} value="/pretzels">
                        Pretzels
                    </NavItem>
                </NavDrawerBody>
            </NavDrawer>
        </div>
    );
};
