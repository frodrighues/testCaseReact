import * as React from 'react';
import * as Bootstrap from 'react-bootstrap';

export default class SideMenu extends React.Component<any, any>{
    public render(): JSX.Element {
        return (
            <Bootstrap.Navbar inverse collapseOnSelect>
                <Bootstrap.Nav>
                    <Bootstrap.NavItem>
                        hello link
                    </Bootstrap.NavItem>
                </Bootstrap.Nav>
            </Bootstrap.Navbar>
        );
    }
}