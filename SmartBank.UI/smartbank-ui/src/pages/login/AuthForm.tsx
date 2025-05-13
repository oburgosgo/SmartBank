import { useState } from "react";
import { Card } from "../../components/ui/Card";
import Login from "./Login";
import SignUp from "./SignUp";
import PhoneOtpVerification from "./PhoneOtpVerification";



export default function AuthForm() {

    const [form, setForm] = useState("");

    const renderAuthComponent = () => {
        switch (form) {

            case "signin":
                return <Login onFormChange={setForm} />
            case "signup":
                return <SignUp onFormChange={setForm} />
            case "verify-phone":
                return <PhoneOtpVerification phoneNumber="" />
            default:
                return <Login onFormChange={setForm} />
        }
    }

    return (
        <div className="flex items-center justify-center h-full w-full">
            <Card className="w-full h-full border-0 md:border shadow-none md:shadow-sm flex flex-col rounded-xl md:rounded-none md:rounded-r-xl">
                {renderAuthComponent()}
            </Card>
        </div>
    )

}