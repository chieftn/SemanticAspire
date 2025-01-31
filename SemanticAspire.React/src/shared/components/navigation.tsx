import * as React from 'react';
import { PreviewLink20Filled, PreviewLink20Regular, bundleIcon } from '@fluentui/react-icons';
import { Tooltip, mergeClasses } from '@fluentui/react-components';
import {
    NavDrawer,
    NavDrawerBody,
    NavDrawerHeader,
    NavItem,
    Hamburger,
    type OnNavItemSelectData,
} from '@fluentui/react-nav-preview';
import { useLocation, useNavigate } from '@tanstack/react-router';
import { useBannerButtonStyles } from '../styles/useBannerButtonStyles';

const PerformanceReviews = bundleIcon(PreviewLink20Filled, PreviewLink20Regular);

export const Navigation: React.FC = () => {
    const [open, setOpen] = React.useState<boolean>(false);
    const { pathname } = useLocation();
    const navigate = useNavigate();
    const { bannerButton, focusIndicator } = useBannerButtonStyles();

    const renderHamburgerWithToolTip = (location?: 'banner') => {
        const className = location === 'banner' ? mergeClasses(bannerButton, focusIndicator) : undefined;
        return (
            <Tooltip content="Navigation" relationship="label">
                <Hamburger className={className} onClick={() => setOpen(!open)} />
            </Tooltip>
        );
    };

    const onSelect = (ev: Event | React.SyntheticEvent<Element, Event>, data: OnNavItemSelectData) => {
        navigate({ to: data.value });
        setOpen(false);
    };

    return (
        <>
            <NavDrawer selectedValue={pathname} open={open} type="overlay" onNavItemSelect={onSelect}>
                <NavDrawerHeader>{renderHamburgerWithToolTip()}</NavDrawerHeader>
                <NavDrawerBody>
                    <NavItem icon={<PerformanceReviews />} value="/">
                        Home
                    </NavItem>
                    <NavItem icon={<PerformanceReviews />} value="/pretzels">
                        Pretzels
                    </NavItem>
                </NavDrawerBody>
            </NavDrawer>
            {!open && renderHamburgerWithToolTip('banner')}
        </>
    );
};
